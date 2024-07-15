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
        public SelectList Locations { get; set; }

        public IList<Employee> Employees { get; set; }
        public IList<TrainerGroup> TrainerGroups { get; set; }

        public async Task<IActionResult> OnGetAsync() {

            var locations = await _context.Locations.ToListAsync();
            Locations = new SelectList(locations, "Id", "Name");

            Employees = await _context.Employees.ToListAsync();
            ViewData["EmployeesJson"] = System.Text.Json.JsonSerializer.Serialize(Employees ?? new List<Employee>());

            TrainerGroups = await _context.TrainerGroups.ToListAsync();
            ViewData["TrainerGroupsJson"] = System.Text.Json.JsonSerializer.Serialize(TrainerGroups ?? new List<TrainerGroup>());

            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {

            if (!ModelState.IsValid) {
                var locations = await _context.Locations.ToListAsync();
                Locations = new SelectList(locations, "Id", "Name");

                Employees = await _context.Employees.ToListAsync();
                ViewData["EmployeesJson"] = System.Text.Json.JsonSerializer.Serialize(Employees ?? new List<Employee>());

                TrainerGroups = await _context.TrainerGroups.ToListAsync();
                ViewData["TrainerGroupsJson"] = System.Text.Json.JsonSerializer.Serialize(TrainerGroups ?? new List<TrainerGroup>());

                return Page();
            }

            _context.TrainingOrders.Add(TrainingOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
