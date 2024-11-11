using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.TrainingOrders {
   [Authorize(Roles = "owner, admin, user")]
   public class ConcludeModel(WCSTrainer.Data.WCSTrainerContext context) : PageModel {
      [BindProperty]
      public TrainingOrder TrainingOrder { get; set; } = default!;
      public string TrainerList;

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var trainingorder = await context.TrainingOrders
             .Include(tr => tr.Trainee)
             .Include(tr => tr.Trainers)
             .FirstOrDefaultAsync(m => m.Id == id);
         if (trainingorder == null) {
            return NotFound();
         }
         TrainingOrder = trainingorder;

         List<string> trainerNames = new List<string>();

         foreach (var trainer in TrainingOrder.Trainers) {
            trainerNames.Add(trainer.FirstName + " " + trainer.LastName);
         }

         TrainerList = string.Join(", ", trainerNames);

         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {

         if (!ModelState.IsValid) {
            return Page();
         }

         var existingTrainingOrder = await context.TrainingOrders.FindAsync(TrainingOrder.Id);
         if (existingTrainingOrder == null) {
            return NotFound();
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

         return RedirectToPage("./Index");
      }

      private bool TrainingOrderExists(int id) {
         return context.TrainingOrders.Any(e => e.Id == id);
      }
   }
}
