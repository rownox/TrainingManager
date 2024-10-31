using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.TrainingOrders {
   [Authorize(Roles = "owner, admin, user, guest")]
   public class IndexModel(WCSTrainer.Data.WCSTrainerContext context) : PageModel {

      public IList<TrainingOrder> TrainingOrder { get; set; } = default!;
      public IList<Employee> Employees { get; set; } = default!;
      public int listCount = 0;

      [BindProperty]
      public int maxCount { get; set; } = 10;

      public async Task OnGetAsync() {
         Employees = await context.Employees.ToListAsync();
         TrainingOrder = await context.TrainingOrders
            .Include(t => t.Trainers)
            .Include(t => t.ParentSkill)
            .Include(t => t.Lesson)
            .ToListAsync();
      }

      public async Task<IActionResult> OnPostAsync(int? id) {
         if (id != null) {
            var trainingOrder = await context.TrainingOrders.FindAsync(id);

            if (trainingOrder == null) {
               return NotFound();
            }

            context.TrainingOrders.Remove(trainingOrder);
            await context.SaveChangesAsync();
         }

         Employees = await context.Employees.ToListAsync();
         TrainingOrder = await context.TrainingOrders.ToListAsync();

         return Page();
      }
   }
}
