using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WCSTrainer.Pages.TrainingOrders {
    public class DeleteModel : PageModel {
        private readonly WCSTrainer.Data.WCSTrainerContext _context;

        public DeleteModel(WCSTrainer.Data.WCSTrainerContext context) {
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
            else {
                TrainingOrder = trainingorder;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id) {

            if (id == null) {
                return NotFound();
            }

            var trainingorder = await _context.TrainingOrder.FindAsync(id);

            if (trainingorder != null) {
                TrainingOrder = trainingorder;
                _context.TrainingOrder.Remove(TrainingOrder);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
