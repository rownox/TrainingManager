using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.TrainingOrders {
    [Authorize(Roles = "admin, trainer")]
    public class EditModel : PageModel {

        private readonly WCSTrainerContext _context;

        public EditModel(WCSTrainerContext context) {
            _context = context;
        }

        [BindProperty]
        public TrainingOrder TrainingOrder { get; set; } = default!;
        [BindProperty]
        public IList<Employee> Employees { get; set; }
        [BindProperty]
        public IList<TrainerGroup> TrainerGroups { get; set; }
        public SelectList Locations { get; set; }
        [BindProperty]
        public string SelectedTrainerString { get; set; }
        public List<int> SelectedTrainerIds { get; set; } = new List<int>();
        public string SelectedTrainerGroupString { get; set; }
        public List<int> SelectedTrainerGroupIds { get; set; } = new List<int>();

        public async Task<IActionResult> OnGetAsync(int? id) {

            if (id == null) {
                return NotFound();
            }

            Employees = await _context.Employees.ToListAsync();
            ViewData["EmployeesJson"] = System.Text.Json.JsonSerializer
                .Serialize(Employees ?? new List<Employee>());

            TrainerGroups = await _context.TrainerGroups.ToListAsync();
            ViewData["TrainerGroupsJson"] = System.Text.Json.JsonSerializer
                .Serialize(TrainerGroups ?? new List<TrainerGroup>());

            var trainingorder = await _context.TrainingOrders
                .Include(t => t.Trainee)
                .Include(t => t.Location)
                .Include(t => t.Trainers)
                .Include(t => t.TrainerGroups)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (trainingorder == null) {
                return NotFound();
            } else {
                TrainingOrder = trainingorder;
            }

            foreach (var trainer in TrainingOrder.Trainers) {
                SelectedTrainerIds.Add(trainer.Id);
            }

            SelectedTrainerIds = TrainingOrder.Trainers.Select(t => t.Id).ToList();
            SelectedTrainerString = string.Join(", ", SelectedTrainerIds);
            Locations = new SelectList(await _context.Locations.ToListAsync(), "Id", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                Employees = await _context.Employees.ToListAsync();
                ViewData["EmployeesJson"] = System.Text.Json.JsonSerializer
                    .Serialize(Employees ?? new List<Employee>());
                TrainerGroups = await _context.TrainerGroups.ToListAsync();
                ViewData["TrainerGroupsJson"] = System.Text.Json.JsonSerializer
                    .Serialize(TrainerGroups ?? new List<TrainerGroup>());

                return Page();
            }

            _context.Attach(TrainingOrder).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!_context.TrainingOrders.Any(e => e.Id == TrainingOrder.Id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            var trainingOrderToUpdate = await _context.TrainingOrders
                .Include(t => t.Trainers)
                .FirstOrDefaultAsync(t => t.Id == TrainingOrder.Id);

            if (trainingOrderToUpdate == null) {
                return NotFound();
            }

            _context.Entry(trainingOrderToUpdate).CurrentValues.SetValues(TrainingOrder);

            List<int> newTrainerIds = SelectedTrainerString.Split(", ").Select(int.Parse).ToList();
            var newTrainers = await _context.Employees
                .Where(e => newTrainerIds.Contains(e.Id))
                .ToListAsync();

            foreach (var trainer in trainingOrderToUpdate.Trainers.ToList()) {
                if (!newTrainerIds.Contains(trainer.Id)) {
                    trainingOrderToUpdate.Trainers.Remove(trainer);
                }
            }

            foreach (var trainer in newTrainers) {
                if (!trainingOrderToUpdate.Trainers.Any(t => t.Id == trainer.Id)) {
                    trainingOrderToUpdate.Trainers.Add(trainer);
                }
            }

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!_context.TrainingOrders.Any(e => e.Id == TrainingOrder.Id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }


            return RedirectToPage("./Index");
        }
    }
}