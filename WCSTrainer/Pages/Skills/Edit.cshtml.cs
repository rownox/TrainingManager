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

      public List<string> SelectedLessonList { get; set; } = new List<string>();

      public List<LessonCategory> LessonCategories { get; set; } = new List<LessonCategory>();

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var skill = await context.Skills
            .Include(s => s.Lessons)
            .FirstOrDefaultAsync(m => m.Id == id);
         if (skill == null) {
            return NotFound();
         }
         Skill = skill;

         var skillCategories = await context.SkillCategories.ToListAsync();

         LessonCategories = await context.LessonCategories
            .Include(lc => lc.Lessons)
            .ToListAsync();
         CategorySelectList = new SelectList(skillCategories, "Id", "Name");
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
