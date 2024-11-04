using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.TrainingOrders {
   [Authorize(Roles = "owner, admin, user, guest")]
   public class IndexModel(Data.WCSTrainerContext context, UserManager<UserAccount> userManager) : PageModel {
      [BindProperty(SupportsGet = true)]
      public TrainingOrderFilterModel Filter { get; set; } = new();

      public class TrainingOrderFilterModel {
         public int MaxCount { get; set; } = 10;
         public string? SearchTerm { get; set; }
         public bool ShowArchived { get; set; }
         public bool ShowVerified { get; set; } = true;
         public bool ShowCompleted { get; set; } = true;
         public bool ShowActive { get; set; } = true;
         public bool ShowAwaiting { get; set; } = true;
         public bool Detailed { get; set; }
      }

      public class TrainingOrderDto {
         public int Id { get; set; }
         public string TraineeName { get; set; } = "";
         public string LessonName { get; set; } = "";
         public string SkillName { get; set; } = "";
         public string Status { get; set; } = "";
         public bool Archived { get; set; }
         public DateOnly? BeginDate { get; set; }
         public string Priority { get; set; } = "";
      }

      public IActionResult OnGet() {
         return Page();
      }

      public async Task<JsonResult> OnGetOrdersAsync([FromQuery] TrainingOrderFilterModel filter) {
         var user = await userManager.GetUserAsync(User);
         if (user == null) return new JsonResult(Array.Empty<TrainingOrderDto>());

         var query = context.TrainingOrders
             .Include(t => t.Trainers)
             .Include(t => t.ParentSkill)
             .Include(t => t.Lesson)
             .Include(t => t.Trainee)
             .AsQueryable();

         if (!filter.ShowArchived)
            query = query.Where(t => !t.Archived);

         var statuses = new List<string>();
         if (filter.ShowVerified) statuses.Add("Verified");
         if (filter.ShowCompleted) statuses.Add("Completed");
         if (filter.ShowActive) statuses.Add("Active");
         if (filter.ShowAwaiting) statuses.Add("Awaiting Approval");

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

         var take = filter.MaxCount == -1
             ? await query.CountAsync()
             : filter.MaxCount;

         take = Math.Min(take, 1000);

         var orders = await query
             .OrderByDescending(t => t.Id)
             .Take(take)
             .Select(t => new TrainingOrderDto {
                Id = t.Id,
                TraineeName = t.Trainee != null ? t.Trainee.FirstName + " " + t.Trainee.LastName : "N/A",
                LessonName = t.Lesson != null ? t.Lesson.Name : "",
                SkillName = t.ParentSkill != null ? t.ParentSkill.Name : "",
                Status = t.Status,
                Archived = t.Archived,
                BeginDate = t.BeginDate,
                Priority = t.Priority != null ? t.Priority : ""
             })
             .ToListAsync();

         return new JsonResult(orders);
      }
   }
}