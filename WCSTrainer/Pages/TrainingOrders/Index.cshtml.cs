using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.TrainingOrders {
   [Authorize(Roles = "owner, admin, user, guest")]
   public class IndexModel(Data.WCSTrainerContext context) : PageModel {

      public IList<TrainingOrder> TrainingOrders { get; set; } = default!;
      public IList<Employee> Employees { get; set; } = default!;
      public int listCount = 0;
      [BindProperty]
      public int MaxCount { get; set; } = 10;
      [BindProperty]
      public bool Detailed { get; set; } = false;

      public async Task<IActionResult> OnGetAsync() {
         await LoadData();
         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         await LoadData();
         return Page();
      }

      public async Task LoadData() {
         Employees = await context.Employees.ToListAsync();
         TrainingOrders = await context.TrainingOrders
            .Include(t => t.Trainers)
            .Include(t => t.ParentSkill)
            .Include(t => t.Lesson)
            .ToListAsync();
      }

      public void switchDetailed() {
         Detailed = !Detailed;
      }
   }
}
