using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.TrainingOrders {
   [Authorize(Roles = "admin, trainer")]
   public class ApprovalModel(Data.WCSTrainerContext context) : PageModel {

      [BindProperty]
      public TrainingOrder TrainingOrder { get; set; } = default!;
      [BindProperty]
      public IList<Employee>? Employees { get; set; }
      [BindProperty]
      public IList<TrainerGroup>? TrainerGroups { get; set; }
      [BindProperty]
      public string? SelectedTrainerString { get; set; }
      public List<int>? SelectedTrainerIds { get; set; }
      [BindProperty]
      public string? SelectedTrainerGroupString { get; set; }
      public List<int>? SelectedTrainerGroupIds { get; set; }

      public async Task<IActionResult> OnGetAsync(int? id) {
         Employees = await context.Employees.ToListAsync();
         ViewData["EmployeesJson"] = System.Text.Json.JsonSerializer
             .Serialize(Employees ?? new List<Employee>());

         TrainerGroups = await context.TrainerGroups.ToListAsync();
         ViewData["TrainerGroupsJson"] = System.Text.Json.JsonSerializer
             .Serialize(TrainerGroups ?? new List<TrainerGroup>());

         if (id == null) {
            return NotFound();
         }

         var trainingorder = await context.TrainingOrders.FirstOrDefaultAsync(m => m.Id == id);
         if (trainingorder == null) {
            return NotFound();
         }
         TrainingOrder = trainingorder;

         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {

         if (!ModelState.IsValid) {
            Employees = await context.Employees.ToListAsync();
            ViewData["EmployeesJson"] = System.Text.Json.JsonSerializer
                .Serialize(Employees ?? new List<Employee>());

            TrainerGroups = await context.TrainerGroups.ToListAsync();
            ViewData["TrainerGroupsJson"] = System.Text.Json.JsonSerializer
                .Serialize(TrainerGroups ?? new List<TrainerGroup>());

            return Page();
         }

         context.Attach(TrainingOrder).State = EntityState.Modified;

         try {
            await context.SaveChangesAsync();
         } catch (DbUpdateConcurrencyException) {
            if (!TrainingOrderExists(TrainingOrder.Id)) {
               return NotFound();
            } else {
               throw;
            }
         }

         if (SelectedTrainerGroupString != null) {
            SelectedTrainerGroupIds = SelectedTrainerGroupString.Split(", ").Select(int.Parse).ToList();

            TrainingOrder.TrainerGroups = await context.TrainerGroups
                    .Where(e => SelectedTrainerGroupIds.Contains(e.Id))
                    .ToListAsync();
         }

         if (SelectedTrainerString != null) {
            SelectedTrainerIds = SelectedTrainerString.Split(", ").Select(int.Parse).ToList();

            TrainingOrder.Trainers = await context.Employees
                .Where(e => SelectedTrainerIds.Contains(e.Id))
                .ToListAsync();
         }

         context.TrainingOrders.Update(TrainingOrder);
         await context.SaveChangesAsync();

         return RedirectToPage("./Index");
      }

      private bool TrainingOrderExists(int id) {
         return context.TrainingOrders.Any(e => e.Id == id);
      }
   }
}
