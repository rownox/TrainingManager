using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;
using WCSTrainer.Models;

namespace WCSTrainer.Pages.TrainingOrders {
    public class CreateModel : PageModel {
        private readonly WCSTrainerContext _context;

        public CreateModel(WCSTrainerContext context) {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync() {
            Employees = await _context.Employee.ToListAsync();
            ViewData["EmployeesJson"] = System.Text.Json.JsonSerializer.Serialize(Employees ?? new List<Employee>());

            TrainerGroups = await _context.TrainerGroup.ToListAsync();
            ViewData["TrainerGroupsJson"] = System.Text.Json.JsonSerializer.Serialize(TrainerGroups ?? new List<TrainerGroup>());
            return Page();
        }

        [BindProperty]
        public TrainingOrder TrainingOrder { get; set; } = new TrainingOrder();

        public DateOnly Day { get; } = DateOnly.FromDateTime(DateTime.Now);

        public IList<Employee> Employees { get; set; }

        [BindProperty]
        public IList<TrainerGroup> TrainerGroups { get; set; }

        [BindProperty]
        public string[] TrainersList { get; set; }

        public async Task<IActionResult> OnPostAsync() {
            if (string.IsNullOrEmpty(TrainingOrder.Description)) {
                TrainingOrder.Description = "None";
            }

            if (!ModelState.IsValid) {
                return Page();
            }

            _context.TrainingOrder.Add(TrainingOrder);

            Employees = await _context.Employee.ToListAsync();

            foreach (Employee employee in Employees) {
                if (TrainingOrder.Trainee.Contains(employee.FirstName) && TrainingOrder.Trainee.Contains(employee.LastName)) {
                    employee.TrainingOrders = employee.TrainingOrders + TrainingOrder.Id + " ";
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
