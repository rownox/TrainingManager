using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WCSTrainer.Pages.TrainingOrders {
    public class IndexModel : PageModel {
        private readonly WCSTrainer.Data.WCSTrainerContext _context;

        public IndexModel(WCSTrainer.Data.WCSTrainerContext context) {
            _context = context;
        }

        public IList<TrainingOrder> TrainingOrder { get; set; } = default!;

        public async Task OnGetAsync() {
            TrainingOrder = await _context.TrainingOrder.ToListAsync();
        }

        public async Task<IActionResult> DeleteTrainingOrderAsync(int id) {
            var trainingOrder = await _context.TrainingOrder.FindAsync(id);

            if (trainingOrder == null) {
                return NotFound();
            }

            _context.TrainingOrder.Remove(trainingOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
