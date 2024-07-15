using AngleSharp.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using WCSTrainer.Data;
using WCSTrainer.Models;

namespace WCSTrainer.Pages.TrainingOrders {
    public class CreateModel : PageModel {
        private readonly WCSTrainerContext _context;

        public CreateModel(WCSTrainerContext context) {
            _context = context;
        }

        [BindProperty]
        public TrainingOrder TrainingOrder { get; set; } = new TrainingOrder();

        public DateOnly Day { get; } = DateOnly.FromDateTime(DateTime.Now);
        public List<int> newList = new List<int>();

        public async Task<IActionResult> OnGetAsync() {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {

            if (!ModelState.IsValid) {
                return Page();
            }

            _context.TrainingOrders.Add(TrainingOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
