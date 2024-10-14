using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.TrainerGroups {
   [Authorize(Roles = "admin, trainer")]
   public class DeleteModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public DeleteModel(WCSTrainer.Data.WCSTrainerContext context) {
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
         } else {
            TrainerGroup = trainergroup;
         }
         return Page();
      }

      public async Task<IActionResult> OnPostAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var trainergroup = await _context.TrainerGroups.FindAsync(id);
         if (trainergroup != null) {
            TrainerGroup = trainergroup;
            _context.TrainerGroups.Remove(TrainerGroup);
            await _context.SaveChangesAsync();
         }

         return RedirectToPage("./Index");
      }
   }
}
