using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Models;

namespace WCSTrainer.Pages.Employees {
    public class DetailsModel : PageModel {
        private readonly WCSTrainer.Data.WCSTrainerContext _context;

        public DetailsModel(WCSTrainer.Data.WCSTrainerContext context) {
            _context = context;
        }

        public Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            var employee = await _context.Employee.FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null) {
                return NotFound();
            } else {
                Employee = employee;
            }
            return Page();
        }
    }
}
