using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Skills {
   [Authorize(Roles = "owner, admin")]
   public class DeleteModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public DeleteModel(WCSTrainer.Data.WCSTrainerContext context) {
         _context = context;
      }

      [BindProperty]
      public Skill Skill { get; set; } = default!;

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var skill = await _context.Skills.FirstOrDefaultAsync(m => m.Id == id);

         if (skill == null) {
            return NotFound();
         } else {
            Skill = skill;
         }
         return Page();
      }

      public async Task<IActionResult> OnPostAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var skill = await _context.Skills.FindAsync(id);
         if (skill != null) {
            Skill = skill;
            _context.Skills.Remove(Skill);
            await _context.SaveChangesAsync();
         }

         return RedirectToPage("./Index");
      }
   }
}
