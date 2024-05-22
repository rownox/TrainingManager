using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;
using WCSTrainer.Models;
using WebApplication2.Models;

namespace WCSTrainer.Pages.TrainingOrders {
    public class CreateModel : PageModel {
        private readonly WCSTrainerContext _context;

        public CreateModel(WCSTrainerContext context) {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync() {
            Employees = await _context.Employee.ToListAsync();
            return Page();
        }

        [BindProperty]
        public TrainingOrder TrainingOrder { get; set; } = new TrainingOrder();

        public DateOnly Day { get; } = DateOnly.FromDateTime(DateTime.Now);

        public IList<Employee> Employees { get; set; }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            _context.TrainingOrder.Add(TrainingOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
