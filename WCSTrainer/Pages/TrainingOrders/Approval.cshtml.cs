using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.TrainingOrders {

   [Authorize(Roles = "owner, admin")]
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
      public SelectList Locations { get; set; }

      public async Task<IActionResult> OnGetAsync(int? id) {
         await initJson();

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

         if (string.IsNullOrWhiteSpace(SelectedTrainerGroupString) & string.IsNullOrWhiteSpace(SelectedTrainerString)) {
            ModelState.AddModelError("SelectedTrainerString", "At least one trainer or trainer group must be selected.");
            await initJson();
            return Page();
         }

         if (!ModelState.IsValid) {
            await initJson();
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
            var groups = await context.TrainerGroups
               .Where(e => SelectedTrainerGroupIds.Contains(e.Id))
               .Include(g => g.Trainers)
               .ToListAsync();
            TrainingOrder.TrainerGroups = groups;
            foreach (var group in groups) {
               var employees = group.Trainers;
               foreach (var employee in employees) {
                  TrainingOrder.Trainers.Add(employee);
               }
            }
         }

         if (SelectedTrainerString != null) {
            SelectedTrainerIds = SelectedTrainerString.Split(", ").Select(int.Parse).ToList();
            TrainingOrder.Trainers = await context.Employees
               .Where(e => SelectedTrainerIds.Contains(e.Id))
               .ToListAsync();
         }

         TrainingOrder.Status = "Scheduling";
         TrainingOrder.ApprovalDate = DateOnly.FromDateTime(DateTime.Now);

         context.TrainingOrders.Update(TrainingOrder);
         await context.SaveChangesAsync();
         return RedirectToPage("./Index");
      }

      private bool TrainingOrderExists(int id) {
         return context.TrainingOrders.Any(e => e.Id == id);
      }

      private async Task initJson() {
         Employees = await context.Employees.ToListAsync();
         TrainerGroups = await context.TrainerGroups.ToListAsync();

         Locations = new SelectList(await context.Locations.ToListAsync(), "Id", "Name");
      }
   }
}
