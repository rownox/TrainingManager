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

            var trainingorder = await _context.TrainingOrder.FirstOrDefaultAsync(m => m.Id == id);
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

            var existingTrainingOrder = await _context.TrainingOrder.FindAsync(TrainingOrder.Id);
            if (existingTrainingOrder == null) {
                return NotFound();
            }

            existingTrainingOrder.Description = TrainingOrder.Description;
            existingTrainingOrder.CreateDate = TrainingOrder.CreateDate;
            existingTrainingOrder.BeginDate = TrainingOrder.BeginDate;
            existingTrainingOrder.Location = TrainingOrder.Location;
            existingTrainingOrder.Duration = TrainingOrder.Duration;
            existingTrainingOrder.Trainee = TrainingOrder.Trainee;
            existingTrainingOrder.EndDate = TrainingOrder.EndDate;
            existingTrainingOrder.Medium = TrainingOrder.Medium;
            existingTrainingOrder.Status = TrainingOrder.Status;

            existingTrainingOrder.Skill = TrainingOrder.Skill;

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
            return _context.TrainingOrder.Any(e => e.Id == id);
        }
    }
}
