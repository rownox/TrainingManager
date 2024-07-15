using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;
using WCSTrainer.Models;

namespace WCSTrainer.Pages.TrainingOrders {
    public class EditModel : PageModel {

        private readonly WCSTrainer.Data.WCSTrainerContext _context;
        private readonly DataUtils _dataUtils;

        public EditModel(WCSTrainer.Data.WCSTrainerContext context, DataUtils dataUtils) {
            _context = context;
            _dataUtils = dataUtils;
        }

        [BindProperty]
        public TrainingOrder TrainingOrder { get; set; } = default!;
        [BindProperty]
        public IList<Employee> Employees { get; set; }
        [BindProperty]
        public IList<TrainerGroup> TrainerGroups { get; set; }

        public IList<Employee> TrainerList { get; set; }
        public Employee Trainee { get; set; }
        public SelectList Locations { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id) {
            Employees = await _context.Employees.ToListAsync();
            ViewData["EmployeesJson"] = System.Text.Json.JsonSerializer.Serialize(Employees ?? new List<Employee>());

            TrainerGroups = await _context.TrainerGroups.ToListAsync();
            ViewData["TrainerGroupsJson"] = System.Text.Json.JsonSerializer.Serialize(TrainerGroups ?? new List<TrainerGroup>());


            if (id == null) {
                return NotFound();
            }

            var trainingorder = await _context.TrainingOrders.FirstOrDefaultAsync(m => m.Id == id);
            if (trainingorder == null) {
                return NotFound();
            }

            TrainingOrder = trainingorder;

            foreach (int trainerId in TrainingOrder.TrainerIds) {
                var trainer = await _dataUtils.GetEmployeeById(trainerId);
                if (trainer != null) {
                    TrainerList.Add(trainer);
                }
            }

            var trainee = await _dataUtils.GetEmployeeById(TrainingOrder.TraineeId);
            if (trainee != null) {
                Trainee = trainee;
            }

            var locations = await _context.Locations.ToListAsync();
            Locations = new SelectList(locations, "Id", "Name");

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