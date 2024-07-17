using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Models;

namespace WCSTrainer.Pages.TrainingOrders {
    public class ConcludeModel : PageModel {
        private readonly WCSTrainer.Data.WCSTrainerContext _context;

        public ConcludeModel(WCSTrainer.Data.WCSTrainerContext context) {
            _context = context;
        }

        [BindProperty]
        public TrainingOrder TrainingOrder { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            var trainingorder = await _context.TrainingOrders
                .Include(tr => tr.Trainers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingorder == null) {
                return NotFound();
            }
            TrainingOrder = trainingorder;

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
            existingTrainingOrder.EndDate = TrainingOrder.EndDate;
            existingTrainingOrder.Medium = TrainingOrder.Medium;
            existingTrainingOrder.Status = TrainingOrder.Status;

            existingTrainingOrder.Skills = TrainingOrder.Skills;

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
