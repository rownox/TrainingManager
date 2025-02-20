using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.TrainingOrders {
   [Authorize(Roles = "owner, admin, user, guest")]
   public class IndexModel(WCSTrainerContext context, UserManager<UserAccount> userManager) : PageModel {
      [BindProperty(SupportsGet = true)]
      public TrainingOrderFilterModel Filter { get; set; } = new();

      public int EarliestYear { get; set; }

      public class TrainingOrderFilterModel {
         public int PageSize { get; set; } = 10;
         public int CurrentPage { get; set; } = 1;
         public string? SearchTerm { get; set; }
         public bool ShowArchived { get; set; }
         public bool ShowVerified { get; set; } = true;
         public bool ShowCompleted { get; set; } = true;
         public bool ShowActive { get; set; } = true;
         public bool ShowScheduling { get; set; } = true;
         public bool ShowApproving { get; set; } = true;
         public bool Detailed { get; set; }
         public int[]? PriorityIds { get; set; }
         public int[]? MonthIds { get; set; }
         public int[]? YearIds { get; set; }
      }

      public class TrainingOrderViewModel {
         public int TotalCount { get; set; }
         public List<TrainingOrderDto> Orders { get; set; } = new();
      }

      public class TrainingOrderDto {
         public int Id { get; set; }
         public string TraineeName { get; set; } = "";
         public string LessonName { get; set; } = "";
         public string SkillName { get; set; } = "";
         public int? SkillId { get; set; }
         public string Status { get; set; } = "";
         public bool Archived { get; set; }
         public string? BeginDate { get; set; }
         public string? Priority { get; set; }
      }

      [BindProperty]
      public TrainingOrderViewModel ViewModel { get; set; } = new();

      public async Task<IActionResult> OnGetAsync() {
         var orders = await context.TrainingOrders
            .Include(o => o.Lesson)
            .ToListAsync();
         EarliestYear = orders
            .Select(t => t.CreateDate.Year)
            .DefaultIfEmpty(DateTime.Now.Year)
            .Min();

         return Page();
      }

      private async Task<IQueryable<TrainingOrder>> FilterOrdersByPermissions(IQueryable<TrainingOrder> query, UserAccount user, Employee currentEmployee) {
         if (await userManager.IsInRoleAsync(user, "owner") || await userManager.IsInRoleAsync(user, "admin"))
            return query;

         var currentEmployeeId = currentEmployee.Id;

         return query.Where(t =>
            (t.CreatedByUserId == user.Id ||
            t.Trainers.Any(tr => tr.Id == currentEmployeeId) ||
            (t.Trainee != null && t.Trainee.Id == currentEmployeeId)) &&
            t.Status != "Approving" && t.Status != "Scheduling"
         );
      }


      public async Task<JsonResult> OnGetOrdersAsync([FromQuery] string priorityIds, [FromQuery] string monthIds, [FromQuery] string yearIds, [FromQuery] TrainingOrderFilterModel filter) {
         var query = context.TrainingOrders
            .Include(t => t.Trainers)
            .Include(t => t.ParentSkill)
            .Include(t => t.Lesson)
            .Include(t => t.Trainee)
            .AsQueryable();

         var user = await userManager.GetUserAsync(User);
         if (user == null) return new JsonResult(new TrainingOrderViewModel());

         var currentEmployee = await context.Employees
            .Include(e => e.TrainingOrdersAsTrainer)
            .Include(e => e.TrainingOrdersAsTrainee)
            .FirstOrDefaultAsync(e => e.Id == user.EmployeeId);

         if (currentEmployee == null)
            return new JsonResult(new TrainingOrderViewModel());

         query = await FilterOrdersByPermissions(query, user, currentEmployee);

         if (!filter.ShowArchived)
            query = query.Where(t => !t.Archived);

         var take = filter.PageSize == -1
            ? await query.CountAsync()
            : filter.PageSize;

         take = Math.Min(take, 1000);

         var statuses = new List<string>();

         if (filter.ShowVerified) statuses.Add("Verified");
         if (filter.ShowCompleted) statuses.Add("Completed");
         if (filter.ShowActive) statuses.Add("Active");
         if (filter.ShowScheduling) statuses.Add("Scheduling");
         if (filter.ShowApproving) statuses.Add("Approving");

         if (statuses.Any())
            query = query.Where(t => statuses.Contains(t.Status));

         query = query.Where(t => t.Trainee == null || t.Trainee.Active);

         if (!string.IsNullOrEmpty(filter.SearchTerm)) {
            query = query.Where(t => (
                t.Trainee.FirstName + " " + t.Trainee.LastName).Contains(filter.SearchTerm) ||
                t.Lesson.Name.Contains(filter.SearchTerm) ||
                t.ParentSkill.Name.Contains(filter.SearchTerm) ||
                t.Id.ToString().Contains(filter.SearchTerm)
            );
         }

         filter.PriorityIds = string.IsNullOrEmpty(priorityIds) ? null : priorityIds.Split(',').Select(int.Parse).ToArray();
         filter.MonthIds = string.IsNullOrEmpty(monthIds) ? null : monthIds.Split(',').Select(int.Parse).ToArray();
         filter.YearIds = string.IsNullOrEmpty(yearIds) ? null : yearIds.Split(',').Select(int.Parse).ToArray();

         if (filter.PriorityIds != null && filter.PriorityIds.Length > 0) {
            var priorityMap = new Dictionary<int, string> {
               { 1, "High" },
               { 2, "Medium" },
               { 3, "Low" }
            };

            var validPriorityNames = filter.PriorityIds
               .Select(id => priorityMap.TryGetValue(id, out var name) ? name : null)
               .Where(name => name != null)
               .ToList();

            if (validPriorityNames.Any()) {
               query = query.Where(t =>
                  t.Priority != null &&
                  validPriorityNames.Contains(t.Priority)
               );
            }
         }

         if (filter.MonthIds != null && filter.MonthIds.Length > 0) {
            var validMonthNumbers = filter.MonthIds.ToList();

            if (validMonthNumbers.Any()) {
               query = query.Where(t =>
                  t.BeginDate != null &&
                  validMonthNumbers.Contains(t.BeginDate.Value.Month)
               );
            }
         }

         if (filter.YearIds != null && filter.YearIds.Length > 0) {
            var validYears = filter.YearIds.ToList();

            if (validYears.Any()) {
               query = query.Where(t =>
                  t.BeginDate != null &&
                  validYears.Contains(t.BeginDate.Value.Year)
               );
            }
         }

         var totalCount = await query.CountAsync();

         List<TrainingOrderDto> orders;
         if (filter.PageSize == -1) {
            orders = await query
               .OrderByDescending(t => t.Id)
               .Select(t => new TrainingOrderDto {
                  Id = t.Id,
                  TraineeName = t.Trainee != null ? t.Trainee.FirstName + " " + t.Trainee.LastName : "N/A",
                  LessonName = t.Lesson != null ? t.Lesson.Name : "",
                  SkillName = t.ParentSkill != null ? t.ParentSkill.Name : "",
                  SkillId = t.ParentSkillId,
                  Status = t.Status,
                  Archived = t.Archived,
                  BeginDate = t.BeginDate != null ? t.BeginDate.Value.ToString("MM/dd/yyyy") : "",
                  Priority = t.Priority != null ? t.Priority : ""
               })
               .ToListAsync();
         } else {
            orders = await query
               .OrderByDescending(t => t.Id)
               .Skip((filter.CurrentPage - 1) * filter.PageSize)
               .Take(filter.PageSize)
               .Select(t => new TrainingOrderDto {
                  Id = t.Id,
                  TraineeName = t.Trainee != null ? t.Trainee.FirstName + " " + t.Trainee.LastName : "N/A",
                  LessonName = t.Lesson != null ? t.Lesson.Name : "",
                  SkillName = t.ParentSkill != null ? t.ParentSkill.Name : "",
                  SkillId = t.ParentSkillId,
                  Status = t.Status,
                  Archived = t.Archived,
                  BeginDate = t.BeginDate != null ? t.BeginDate.Value.ToString("MM/dd/yyyy") : "",
                  Priority = t.Priority != null ? t.Priority : ""
               })
               .ToListAsync();
         }

         return new JsonResult(new TrainingOrderViewModel {
            TotalCount = totalCount,
            Orders = orders
         });
      }
   }
}