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
        public TrainingOrder deletionOrder { get; set; } = default!;

        public int? idnum = null;

        public async Task OnGetAsync() {
            TrainingOrder = await _context.TrainingOrder.ToListAsync();
        }

        public async void setDeletionOrder() {
            if (idnum == null) {
                return;
            }

            var trainingorder = await _context.TrainingOrder.FirstOrDefaultAsync(m => m.Id == idnum);

            if (trainingorder == null) {
                return;
            } else {
                deletionOrder = trainingorder;
            }
        }

        public async Task<IActionResult> deleteOrder() {

            setDeletionOrder();

            int? id = null;
            if (deletionOrder != null) {
                id = deletionOrder.Id;
            }
            
            if (id == null) {
                return NotFound();
            }

            var trainingorder = await _context.TrainingOrder.FindAsync(id);

            if (trainingorder != null) {
                foreach (TrainingOrder order in _context.TrainingOrder) {
                    if (order.Id == id) {
                        deletionOrder = trainingorder;
                        _context.TrainingOrder.Remove(deletionOrder);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            return RedirectToPage("./Index");
        }
    }
}
