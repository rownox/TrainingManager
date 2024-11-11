using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.TrainingOrders
{
    public class SchedulingModel(Data.WCSTrainerContext context) : PageModel {
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
         if (TrainingOrder.BeginDate == null) {
            ModelState.AddModelError("BeginDate", "Please select a beginning date.");
            return Page();
         }

         if (!ModelState.IsValid) {
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

         TrainingOrder.Status = "Active";
         TrainingOrder.ScheduleDate = DateOnly.FromDateTime(DateTime.Now);

         context.TrainingOrders.Update(TrainingOrder);
         await context.SaveChangesAsync();
         return RedirectToPage("./Index");
      }

      private bool TrainingOrderExists(int id) {
         return context.TrainingOrders.Any(e => e.Id == id);
      }
   }
}
