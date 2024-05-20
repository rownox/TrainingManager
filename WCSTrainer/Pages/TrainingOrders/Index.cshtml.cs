using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Models;
using WebApplication2.Models;

namespace WCSTrainer.Pages.TrainingOrders {
    public class IndexModel : PageModel {
        private readonly WCSTrainer.Data.WCSTrainerContext _context;
        private readonly WCSTrainer.Data.EmployeeContext _context2;

        public IndexModel(WCSTrainer.Data.WCSTrainerContext context, WCSTrainer.Data.EmployeeContext context2) {
            _context = context;
            _context2 = context2;
        }

        public IList<TrainingOrder> TrainingOrder { get; set; } = default!;
        public IList<Employee> Employees { get; set; }

        public async Task OnGetAsync() {
            Employees = await _context2.Employee.ToListAsync();
            TrainingOrder = await _context.TrainingOrder.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(int id) {
            var trainingOrder = await _context.TrainingOrder.FindAsync(id);

            if (trainingOrder == null) {
                return NotFound();
            }

            _context.TrainingOrder.Remove(trainingOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public string getEmployee(string traineeID) {
            foreach(Employee employee in Employees) {
                if (employee.Id.ToString().Equals(traineeID)) {
                    return employee.FirstName + " " + employee.LastName;
                }
            }
            return traineeID;
        }
    }
}
