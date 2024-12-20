using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Skills {
   [Authorize(Roles = "owner, admin")]
   public class EditModel(WCSTrainer.Data.WCSTrainerContext context) : PageModel {
      [BindProperty]
      public Skill Skill { get; set; } = default!;

      public SelectList CategorySelectList { get; set; }

      public async Task<IActionResult> OnGetAsync(int? id) {
         CategorySelectList = new SelectList(await context.SkillCategories.ToListAsync(), "Id", "Name");

         if (id == null) {
            return NotFound();
         }

         var skill = await context.Skills.FirstOrDefaultAsync(m => m.Id == id);
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

         context.Attach(Skill).State = EntityState.Modified;

         try {
            await context.SaveChangesAsync();
         } catch (DbUpdateConcurrencyException) {
            if (!SkillExists(Skill.Id)) {
               return NotFound();
            } else {
               throw;
            }
         }

         return RedirectToPage("/Skills/Details", new { Skill.Id });
      }

      private bool SkillExists(int id) {
         return context.Skills.Any(e => e.Id == id);
      }
   }
}
