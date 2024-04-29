using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Models;

namespace WCSTrainer.Pages.TrainingOrders
{
    public class CreateModel : PageModel
    {
        private readonly WCSTrainer.Data.WCSTrainerContext _context;

        public CreateModel(WCSTrainer.Data.WCSTrainerContext context) {
            _context = context;
        }

        public IActionResult OnGet() {
            return Page();
        }

        [BindProperty]
        public TrainingOrder TrainingOrder { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TrainingOrder.Add(TrainingOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
