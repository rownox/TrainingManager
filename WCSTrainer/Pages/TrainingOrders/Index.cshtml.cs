// IndexModel.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using WCSTrainer.Data;
using WCSTrainer.Helpers;

namespace WCSTrainer.Pages.TrainingOrders {
   [Authorize(Roles = "owner, admin, user, guest")]
   public class IndexModel(Data.WCSTrainerContext context, UserManager<UserAccount> userManager) : PageModel {
      [BindProperty(SupportsGet = true)]
      public TrainingOrderFilterModel Filter { get; set; } = new();

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
         return Page();
      }

      private async Task<IQueryable<TrainingOrder>> FilterOrdersByPermissions(IQueryable<TrainingOrder> query, UserAccount user, Employee currentEmployee) {
         if (await userManager.IsInRoleAsync(user, "owner") || await userManager.IsInRoleAsync(user, "admin"))
            return query;

         var currentEmployeeId = currentEmployee.Id;

         return query.Where(t => t.CreatedByUserId == user.Id || t.Trainers.Any(tr => tr.Id == currentEmployeeId) || (t.Trainee != null && t.Trainee.Id == currentEmployeeId));
      }

      public async Task<JsonResult> OnGetOrdersAsync([FromQuery] TrainingOrderFilterModel filter) {
         var user = await userManager.GetUserAsync(User);
         if (user == null) return new JsonResult(new TrainingOrderViewModel());

         var currentEmployee = await context.Employees
            .Include(e => e.TrainingOrdersAsTrainer)
            .Include(e => e.TrainingOrdersAsTrainee)
            .FirstOrDefaultAsync(e => e.Id == user.EmployeeId);

         if (currentEmployee == null)
            return new JsonResult(new TrainingOrderViewModel());

         var query = context.TrainingOrders
            .Include(t => t.Trainers)
            .Include(t => t.ParentSkill)
            .Include(t => t.Lesson)
            .Include(t => t.Trainee)
            .AsQueryable();

         query = await FilterOrdersByPermissions(query, user, currentEmployee);

         if(!filter.ShowArchived)
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

         if (!string.IsNullOrEmpty(filter.SearchTerm)) {
            query = query.Where(t => (
                t.Trainee.FirstName + " " + t.Trainee.LastName).Contains(filter.SearchTerm) ||
                t.Lesson.Name.Contains(filter.SearchTerm) ||
                t.ParentSkill.Name.Contains(filter.SearchTerm) ||
                t.Id.ToString().Contains(filter.SearchTerm)
            );
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