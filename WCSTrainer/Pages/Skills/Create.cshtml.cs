using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WCSTrainer.Pages.Skills {
   [Authorize(Roles = "owner, admin")]
   public class CreateModel(Data.WCSTrainerContext context) : PageModel {
      [BindProperty]
      public Skill Skill { get; set; } = default!;
      [BindProperty]
      public List<string> SelectedLessonList { get; set; } = new List<string>();
      public SelectList LessonSelectList { get; set; }

      public async Task<IActionResult> OnGetAsync() {
         LessonSelectList = new SelectList(await context.Lessons.ToListAsync(), "Id", "Name");
         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            return Page();
         }

         if (SelectedLessonList == null) {
            return Page();
         }

         context.Skills.Add(Skill);
         await context.SaveChangesAsync();
         
         foreach (var option in SelectedLessonList) {
            var lesson = await context.Lessons.FirstOrDefaultAsync(l => l.Id.ToString() == option);
            if (lesson != null) {
               Skill.Lessons.Add(lesson);
            }
         }

         context.Skills.Update(Skill);
         await context.SaveChangesAsync();

         return RedirectToPage("./Index");
      }
   }
}
