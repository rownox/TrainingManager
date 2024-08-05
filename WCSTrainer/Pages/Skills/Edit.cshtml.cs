using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Skills {
   public class EditModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public EditModel(WCSTrainer.Data.WCSTrainerContext context) {
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
         }
         Skill = skill;
         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            return Page();
         }

         _context.Attach(Skill).State = EntityState.Modified;

         try {
            await _context.SaveChangesAsync();
         } catch (DbUpdateConcurrencyException) {
            if (!SkillExists(Skill.Id)) {
               return NotFound();
            } else {
               throw;
            }
         }

         return RedirectToPage("./Index");
      }

      private bool SkillExists(int id) {
         return _context.Skills.Any(e => e.Id == id);
      }
   }
}
