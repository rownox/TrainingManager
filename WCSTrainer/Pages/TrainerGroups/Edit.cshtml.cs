using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.TrainerGroups {
   [Authorize(Roles = "owner, admin")]
   public class EditModel(Data.WCSTrainerContext context) : PageModel {
      [BindProperty]
      public TrainerGroup TrainerGroup { get; set; } = default!;
      [BindProperty]
      public string SelectedEmployeeIdString { get; set; } = default!;
      public IList<Employee>? Employees { get; set; }

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var trainergroup = await context.TrainerGroups
            .Include(t => t.Trainers)
            .FirstOrDefaultAsync(m => m.Id == id);
         if (trainergroup == null) {
            return NotFound();
         }
         TrainerGroup = trainergroup;
         Employees = await context.Employees.ToListAsync();
         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            Employees = await context.Employees.ToListAsync();
            return Page();
         }

         context.Attach(TrainerGroup).State = EntityState.Modified;
         var trainerGroupToUpdate = await context.TrainerGroups
             .Include(t => t.Trainers)
             .FirstOrDefaultAsync(t => t.Id == TrainerGroup.Id);

         if (trainerGroupToUpdate == null) {
            return NotFound();
         }

         context.Entry(trainerGroupToUpdate).CurrentValues.SetValues(TrainerGroup);
         if (SelectedEmployeeIdString != null) {
            List<int> newTrainerIds = SelectedEmployeeIdString.Split(", ").Select(int.Parse).ToList();
            var newTrainers = await context.Employees
                .Where(e => newTrainerIds.Contains(e.Id))
                .ToListAsync();
            trainerGroupToUpdate.Trainers = newTrainers;
         } else {
            trainerGroupToUpdate.Trainers.Clear();
         }

         try {
            await context.SaveChangesAsync();
         } catch (DbUpdateConcurrencyException) {
            if (!TrainerGroupExists(TrainerGroup.Id)) {
               return NotFound();
            } else {
               throw;
            }
         }

         return RedirectToPage("./Index");
      }

      private bool TrainerGroupExists(int id) {
         return context.TrainerGroups.Any(e => e.Id == id);
      }
   }
}
