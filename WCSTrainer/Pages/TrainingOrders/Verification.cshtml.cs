using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Models;

namespace WCSTrainer.Pages.TrainingOrders {
    [Authorize(Roles = "admin, trainer")]
    public class VerificationModel : PageModel {
        private readonly WCSTrainer.Data.WCSTrainerContext _context;

        public VerificationModel(WCSTrainer.Data.WCSTrainerContext context) {
            _context = context;
        }

        [BindProperty]
        public TrainingOrder TrainingOrder { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            var trainingorder = await _context.TrainingOrders
                .Include(t => t.Trainers)
                .Include(t => t.Location)
                .Include(t => t.Trainee)
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

            _context.TrainingOrders.Update(TrainingOrder);

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
