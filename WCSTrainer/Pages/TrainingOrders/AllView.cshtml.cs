using Microsoft.AspNetCore.Mvc;
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
        public int listCount = 0;
        [BindProperty]
        public int maxCount { get; set; } = 15;
        [BindProperty]
        public DateOnly From { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [BindProperty]
        public DateOnly To { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public async Task OnGetAsync() {
            TrainingOrder = await _context.TrainingOrder.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync() {
            TrainingOrder = await _context.TrainingOrder.ToListAsync();

            return Page();
        }
    }
}