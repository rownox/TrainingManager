using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.TrainingOrders {
   [Authorize(Roles = "owner")]
   public class DeleteModel(Data.WCSTrainerContext context) : PageModel {

      [BindProperty]
      public TrainingOrder TrainingOrder { get; set; } = default!;

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var trainingOrder = await context.TrainingOrders.FirstOrDefaultAsync(m => m.Id == id);

         if (trainingOrder == null) {
            return NotFound();
         } else {
            TrainingOrder = trainingOrder;
         }
         return Page();
      }

      public async Task<IActionResult> OnPostAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var trainingOrder = await context.TrainingOrders.FindAsync(id);
         if (trainingOrder != null) {
            TrainingOrder = trainingOrder;
            context.TrainingOrders.Remove(TrainingOrder);
            await context.SaveChangesAsync();
         }

         return RedirectToPage("./Index");
      }
   }
}
