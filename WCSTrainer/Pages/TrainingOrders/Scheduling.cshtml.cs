using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.TrainingOrders
{
    public class SchedulingModel(Data.WCSTrainerContext context) : PageModel {

      [BindProperty]
      public TrainingOrder TrainingOrder { get; set; } = default!;

      public async Task<IActionResult> OnGetAsync(int? id) {
         var trainingorder = await context.TrainingOrders.FirstOrDefaultAsync(m => m.Id == id);
         if (trainingorder == null) {
            return NotFound();
         }

         TrainingOrder = trainingorder;
         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         if (TrainingOrder.BeginDate == null) {
            ModelState.AddModelError("BeginDate", "Please select a beginning date.");
            return Page();
         }

         if (!ModelState.IsValid) {
            return Page();
         }

         try {
            await context.SaveChangesAsync();
         } catch (DbUpdateConcurrencyException) {
            if (!TrainingOrderExists(TrainingOrder.Id)) {
               return NotFound();
            } else {
               throw;
            }
         }

         context.TrainingOrders.Update(TrainingOrder);
         await context.SaveChangesAsync();
         return RedirectToPage("./Index");
      }

      private bool TrainingOrderExists(int id) {
         return context.TrainingOrders.Any(e => e.Id == id);
      }
   }
}
