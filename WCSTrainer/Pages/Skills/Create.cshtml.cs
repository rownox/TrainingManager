using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Skills {
   [Authorize(Roles = "owner, admin")]
   public class CreateModel(Data.WCSTrainerContext context) : PageModel {
      [BindProperty]
      public Skill Skill { get; set; } = default!;
      [BindProperty]
      public string? LessonString { get; set; }
      public SelectList LessonSelectList { get; set; }

      public async Task<IActionResult> OnGetAsync() {
         LessonSelectList = new SelectList(await context.Lessons.ToListAsync(), "Id", "Name");
         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            return Page();
         }

         context.Skills.Add(Skill);
         await context.SaveChangesAsync();

         if (LessonString != null) {
            var lessonIds = LessonString.Split(", ").Select(int.Parse).ToList();

            Skill.Lessons = await context.Lessons
                .Where(e => lessonIds.Contains(e.Id))
                .ToListAsync();
         }

         context.Skills.Update(Skill);
         await context.SaveChangesAsync();

         return RedirectToPage("./Index");
      }
   }
}
