using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Models;
using WebApplication2.Models;

namespace WCSTrainer.Pages.TrainingOrders {
    public class DetailsModel : PageModel {
        private readonly WCSTrainer.Data.WCSTrainerContext _context;

        public DetailsModel(WCSTrainer.Data.WCSTrainerContext context) {
            _context = context;
        }

        public TrainingOrder TrainingOrder { get; set; } = default!;

        public IList<Employee> Employees { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id) {
            Employees = await _context.Employee.ToListAsync();

            if (id == null) {
                return NotFound();
            }

            var trainingorder = await _context.TrainingOrder.FirstOrDefaultAsync(m => m.Id == id);
            if (trainingorder == null) {
                return NotFound();
            } else {
                TrainingOrder = trainingorder;
            }

            return Page();
        }
    }
}
