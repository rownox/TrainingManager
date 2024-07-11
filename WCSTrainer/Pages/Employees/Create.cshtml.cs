using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WCSTrainer.Models;

namespace WCSTrainer.Pages.Employees {
    public class CreateModel : PageModel {
        private readonly WCSTrainer.Data.WCSTrainerContext _context;

        public CreateModel(WCSTrainer.Data.WCSTrainerContext context) {
            _context = context;
        }

        public IActionResult OnGet() {
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
