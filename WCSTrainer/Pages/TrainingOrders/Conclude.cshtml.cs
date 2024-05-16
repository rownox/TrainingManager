using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WCSTrainer.Pages.TrainingOrders
{
    public class ConcludeModel : PageModel
    {
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

            existingTrainingOrder.status = TrainingOrder.status;
            existingTrainingOrder.description = TrainingOrder.description;
            existingTrainingOrder.createDate = TrainingOrder.createDate;
            existingTrainingOrder.beginDate = TrainingOrder.beginDate;
            existingTrainingOrder.location = TrainingOrder.location;
            existingTrainingOrder.duration = TrainingOrder.duration;
            existingTrainingOrder.trainee = TrainingOrder.trainee;
            existingTrainingOrder.endDate = TrainingOrder.endDate;
            existingTrainingOrder.medium = TrainingOrder.medium;
            existingTrainingOrder.skill = TrainingOrder.skill;

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
