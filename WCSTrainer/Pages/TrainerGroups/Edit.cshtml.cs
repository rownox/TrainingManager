using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.TrainerGroups {
   [Authorize(Roles = "admin, trainer")]
   public class EditModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public EditModel(WCSTrainer.Data.WCSTrainerContext context) {
         _context = context;
      }

      [BindProperty]
      public TrainerGroup TrainerGroup { get; set; } = default!;

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var trainergroup = await _context.TrainerGroups.FirstOrDefaultAsync(m => m.Id == id);
         if (trainergroup == null) {
            return NotFound();
         }
         TrainerGroup = trainergroup;
         return Page();
      } 

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            return Page();
         }

         _context.Attach(TrainerGroup).State = EntityState.Modified;

         try {
            await _context.SaveChangesAsync();
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
         return _context.TrainerGroups.Any(e => e.Id == id);
      }
   }
}
