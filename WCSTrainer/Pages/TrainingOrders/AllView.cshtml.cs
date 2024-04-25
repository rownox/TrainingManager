using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WCSTrainer.Pages.TrainingOrders {
    public class AllViewModel : PageModel {
        private readonly WCSTrainer.Data.WCSTrainerContext _context;

        public AllViewModel(WCSTrainer.Data.WCSTrainerContext context) {
            _context = context;
        }

        public IList<TrainingOrder> TrainingOrder { get; set; } = default!;

        public async Task OnGetAsync() {
            TrainingOrder = await _context.TrainingOrder.ToListAsync();
        }
    }
}