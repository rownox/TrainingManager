using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.Skills {
   public class AssignModel : PageModel {

      private readonly WCSTrainerContext _context;
      public AssignModel(WCSTrainerContext context) {
         _context = context;
      }

      public Skill Skill { get; set; } = default!;
      [BindProperty]
      public IList<Employee> Employees { get; set; }
      [BindProperty]
      public IList<TrainerGroup> TrainerGroups { get; set; }
      [BindProperty]
      public string? SelectedTrainerString { get; set; }
      public List<int> SelectedTrainerIds { get; set; } = new List<int>();
      [BindProperty]
      public string? SelectedTrainerGroupString { get; set; }
      public List<int> SelectedTrainerGroupIds { get; set; } = new List<int>();
      public int SelectedTraineeId { get; set; }


      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var skill = await _context.Skills
             .Include(s => s.Employees)
             .Include(s => s.TrainingOrders)
             .FirstOrDefaultAsync(m => m.Id == id);
         if (skill == null) {
            return NotFound();
         } else {
            Skill = skill;
         }

         Employees = await _context.Employees.ToListAsync();
         ViewData["EmployeesJson"] = System.Text.Json.JsonSerializer
             .Serialize(Employees ?? new List<Employee>());
         TrainerGroups = await _context.TrainerGroups.ToListAsync();
         ViewData["TrainerGroupsJson"] = System.Text.Json.JsonSerializer
             .Serialize(TrainerGroups ?? new List<TrainerGroup>());

         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {

         if (!ModelState.IsValid) {
            int? id = Skill.Id;
            await OnGetAsync(id);
         }

         var trainee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == SelectedTraineeId);
         if (trainee == null) {
            return Page();
         }

         List<TrainerGroup> trainerGroups = new List<TrainerGroup>();
         List<Employee> trainers = new List<Employee>();

         if (SelectedTrainerGroupString != null) {
            SelectedTrainerGroupIds = SelectedTrainerGroupString.Split(", ").Select(int.Parse).ToList();
            var newTrainerGroups = await _context.TrainerGroups
                    .Where(e => SelectedTrainerGroupIds.Contains(e.Id))
                    .ToListAsync();
            foreach (var i in newTrainerGroups) {
               trainerGroups.Add(i);
            }
         }

         if (SelectedTrainerString != null) {
            SelectedTrainerIds = SelectedTrainerString.Split(", ").Select(int.Parse).ToList();
            var newTrainers = await _context.Employees
                .Where(e => SelectedTrainerIds.Contains(e.Id))
                .ToListAsync();
            foreach (var i in newTrainers) {
               trainers.Add(i);
            }
         }

         foreach (var trainingOrder in Skill.TrainingOrders) {
            var orderDuplicate = new TrainingOrder {
               Description = trainingOrder.Description,
               Duration = trainingOrder.Duration,
               LocationId = trainingOrder.LocationId,
               Medium = trainingOrder.Medium,
               Status = trainingOrder.Status,
               Trainee = trainee,
               TrainerGroups = trainerGroups,
               Trainers = trainers
            };

            trainee.TrainingOrdersAsTrainee.Add(orderDuplicate);
         }

         trainee.Skills.Add(Skill);

         try {
            await _context.SaveChangesAsync();
         } catch (DbUpdateConcurrencyException) {
            if (!_context.Employees.Any(e => e.Id == trainee.Id)) {
               return NotFound();
            } else {
               throw;
            }
         }

         return Page();
      }
   }
}
