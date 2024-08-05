using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.TrainingOrders {
   [Authorize(Roles = "admin, trainer")]
   public class ConcludeModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public ConcludeModel(WCSTrainer.Data.WCSTrainerContext context) {
         _context = context;
      }

      [BindProperty]
      public TrainingOrder TrainingOrder { get; set; } = default!;
      public string TrainerList;

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var trainingorder = await _context.TrainingOrders
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

         var existingTrainingOrder = await _context.TrainingOrders.FindAsync(TrainingOrder.Id);
         if (existingTrainingOrder == null) {
            return NotFound();
         }

         existingTrainingOrder.CreateDate = TrainingOrder.CreateDate;
         existingTrainingOrder.BeginDate = TrainingOrder.BeginDate;
         existingTrainingOrder.LocationId = TrainingOrder.LocationId;
         existingTrainingOrder.Duration = TrainingOrder.Duration;
         existingTrainingOrder.TraineeId = TrainingOrder.TraineeId;
         existingTrainingOrder.CompletionDate = TrainingOrder.CompletionDate;
         existingTrainingOrder.Medium = TrainingOrder.Medium;
         existingTrainingOrder.Status = TrainingOrder.Status;
         existingTrainingOrder.ClosingNotes = TrainingOrder.ClosingNotes;

         _context.Entry(existingTrainingOrder).State = EntityState.Modified;

         try {
            await _context.SaveChangesAsync();
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
         return _context.TrainingOrders.Any(e => e.Id == id);
      }
   }
}
