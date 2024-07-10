using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Models;

namespace WCSTrainer.Pages.TrainingOrders {
    public class EditModel : PageModel {

        private readonly WCSTrainer.Data.WCSTrainerContext _context;

        public EditModel(WCSTrainer.Data.WCSTrainerContext context) {
            _context = context;
        }

        [BindProperty]
        public TrainingOrder TrainingOrder { get; set; } = default!;
        [BindProperty]
        public IList<Employee> Employees { get; set; }
        [BindProperty]
        public IList<TrainerGroup> TrainerGroups { get; set; }
        [BindProperty]
        public string[] TrainersList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id) {
            Employees = await _context.Employee.ToListAsync();
            ViewData["EmployeesJson"] = System.Text.Json.JsonSerializer.Serialize(Employees ?? new List<Employee>());

            TrainerGroups = await _context.TrainerGroup.ToListAsync();
            ViewData["TrainerGroupsJson"] = System.Text.Json.JsonSerializer.Serialize(TrainerGroups ?? new List<TrainerGroup>());


            if (id == null) {
                return NotFound();
            }

            var trainingorder = await _context.TrainingOrder.FirstOrDefaultAsync(m => m.Id == id);
            if (trainingorder == null) {
                return NotFound();
            }

            TrainingOrder = trainingorder;

            TrainersList = TrainingOrder.Trainers.Split(',');

            return Page();
        }


        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                Employees = await _context.Employee.ToListAsync();
                ViewData["EmployeesJson"] = System.Text.Json.JsonSerializer.Serialize(Employees ?? new List<Employee>());
                TrainerGroups = await _context.TrainerGroup.ToListAsync();
                ViewData["TrainerGroupsJson"] = System.Text.Json.JsonSerializer.Serialize(TrainerGroups ?? new List<TrainerGroup>());

                TrainersList = TrainingOrder.Trainers.Split(',');

                return Page();
            }

            _context.Attach(TrainingOrder).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!TrainingOrderExists(TrainingOrder.Id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }
            return RedirectToPage("./Index");
        }

        private bool TrainingOrderExists(int id) {
            return _context.TrainingOrder.Any(e => e.Id == id);
        }
    }
}