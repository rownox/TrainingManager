using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Models;
using WebApplication2.Models;

namespace WCSTrainer.Pages.TrainingOrders {
    public class IndexModel : PageModel {
        private readonly WCSTrainer.Data.WCSTrainerContext _context;

        public IndexModel(WCSTrainer.Data.WCSTrainerContext context) {
            _context = context;
        }

        public IList<TrainingOrder> TrainingOrder { get; set; } = default!;
        public IList<Employee> Employees { get; set; }
        public int listCount = 0;
        [BindProperty]
        public int maxCount { get; set; } = 10;

        public async Task OnGetAsync() {
            Employees = await _context.Employee.ToListAsync();
            TrainingOrder = await _context.TrainingOrder.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(int? id) {
            if (id != null) {
                var trainingOrder = await _context.TrainingOrder.FindAsync(id);

                if (trainingOrder == null) {
                    return NotFound();
                }

                _context.TrainingOrder.Remove(trainingOrder);
                await _context.SaveChangesAsync();
            }

            Employees = await _context.Employee.ToListAsync();
            TrainingOrder = await _context.TrainingOrder.ToListAsync();

            return Page();
        }

        public string getEmployee(string traineeID) {
            foreach (Employee employee in Employees) {
                if (employee.Id.ToString().Equals(traineeID)) {
                    return employee.FirstName + " " + employee.LastName;
                }
            }
            return traineeID;
        }
    }
}
