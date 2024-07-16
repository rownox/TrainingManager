using AngleSharp.Common;
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

        [BindProperty]
        public TrainingOrder TrainingOrder { get; set; } = new TrainingOrder();

        public DateOnly Day { get; } = DateOnly.FromDateTime(DateTime.Now);
        public IList<Location> Locations { get; set; }
        public IList<Employee> Employees { get; set; }
        public IList<TrainerGroup> TrainerGroups { get; set; }

        public async Task<IActionResult> OnGetAsync() {
            Locations = await _context.Locations.ToListAsync();
            Employees = await _context.Employees.ToListAsync();
            TrainerGroups = await _context.TrainerGroups.ToListAsync();

            ViewData["EmployeesJson"] = System.Text.Json.JsonSerializer.Serialize(Employees ?? new List<Employee>());
            ViewData["TrainerGroupsJson"] = System.Text.Json.JsonSerializer.Serialize(TrainerGroups ?? new List<TrainerGroup>());

            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {

            TrainingOrder.Trainee = await _context.Employees.FindAsync(1);
            TrainingOrder.Location = await _context.Locations.FindAsync(1);

            if (!ModelState.IsValid) {
                Locations = await _context.Locations.ToListAsync();
                Employees = await _context.Employees.ToListAsync();
                TrainerGroups = await _context.TrainerGroups.ToListAsync();

                ViewData["EmployeesJson"] = System.Text.Json.JsonSerializer.Serialize(Employees ?? new List<Employee>());
                ViewData["TrainerGroupsJson"] = System.Text.Json.JsonSerializer.Serialize(TrainerGroups ?? new List<TrainerGroup>());

                return Page();
            }

            _context.TrainingOrders.Update(TrainingOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


    }
}
