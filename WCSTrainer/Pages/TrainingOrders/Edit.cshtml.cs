using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;
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

        public IList<Employee> TrainerList { get; set; } = new List<Employee>();
        public SelectList Locations { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id) {
            Employees = await _context.Employees.ToListAsync();
            ViewData["EmployeesJson"] = System.Text.Json.JsonSerializer.Serialize(Employees ?? new List<Employee>());

            TrainerGroups = await _context.TrainerGroups.ToListAsync();
            ViewData["TrainerGroupsJson"] = System.Text.Json.JsonSerializer.Serialize(TrainerGroups ?? new List<TrainerGroup>());

            if (id == null) {
                return NotFound();
            }

            var trainingorder = await _context.TrainingOrders
                .Include(t => t.Trainee)
                .Include(l => l.Location)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (trainingorder == null) {
                return NotFound();
            } else {
                TrainingOrder = trainingorder;
            }

            if (TrainingOrder.Trainers != null) {
                foreach (var trainer in TrainingOrder.Trainers) {
                    if (trainer != null) {
                        TrainerList.Add(trainer);
                    }
                }
            }

            Locations = new SelectList(await _context.Locations.ToListAsync(), "Id", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                Employees = await _context.Employees.ToListAsync();
                ViewData["EmployeesJson"] = System.Text.Json.JsonSerializer.Serialize(Employees ?? new List<Employee>());
                TrainerGroups = await _context.TrainerGroups.ToListAsync();
                ViewData["TrainerGroupsJson"] = System.Text.Json.JsonSerializer.Serialize(TrainerGroups ?? new List<TrainerGroup>());

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
            return _context.TrainingOrders.Any(e => e.Id == id);
        }
    }
}