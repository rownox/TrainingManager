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
      public string? SelectedTrainerString { get; set; }
      public List<int> SelectedTrainerIds { get; set; } = new List<int>();
      [BindProperty]
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
         Employees = await context.Employees
            .Include(e => e.TrainerDepartments)
            .ToListAsync();

         foreach (var trainer in TrainerGroup.Trainers) {
            SelectedTrainerIds.Add(trainer.Id);
         }
         SelectedTrainerIds = TrainerGroup.Trainers.Select(t => t.Id).ToList();
         SelectedTrainerString = string.Join(", ", SelectedTrainerIds);
         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            Employees = await context.Employees.ToListAsync();
            return Page();
         }

         context.Attach(TrainerGroup).State = EntityState.Modified;

         var currentTrainers = await context.Entry(TrainerGroup)
             .Collection(tg => tg.Trainers)
             .Query()
             .ToListAsync();
         TrainerGroup.Trainers.Clear();

         if (SelectedTrainerString != null) {
            List<int> newTrainerIds = SelectedTrainerString.Split(", ").Select(int.Parse).ToList();
            var newTrainers = await context.Employees
                .Where(e => newTrainerIds.Contains(e.Id))
                .ToListAsync();
            TrainerGroup.Trainers = newTrainers;
         }

         try {
            await context.SaveChangesAsync();
         } catch (DbUpdateConcurrencyException) {
            return NotFound();
         }
         return RedirectToPage("/TrainerGroups/Details", new { TrainerGroup.Id });
      }

   }
}
