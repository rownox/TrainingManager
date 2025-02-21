using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Skills {
   [Authorize(Roles = "owner, admin")]
   public class CreateModel(Data.WCSTrainerContext context) : PageModel {
      [BindProperty]
      public Skill Skill { get; set; } = new Skill();
      [BindProperty]
      public List<string> SelectedLessonList { get; set; } = new List<string>();
      public List<LessonCategory> LessonCategories { get; set; } = new List<LessonCategory>();
      public SelectList? CategorySelectList { get; set; }
      public Dictionary<Lesson, string> Lessons { get; set; } = new Dictionary<Lesson, string>();

      public async Task OnGetAsync() {
         var lessons = await context.Lessons.ToListAsync();
         var skillCategories = await context.SkillCategories.ToListAsync();

         LessonCategories = await context.LessonCategories
            .Include(lc => lc.Lessons)
            .ToListAsync();
         CategorySelectList = new SelectList(skillCategories, "Id", "Name");

         foreach (var category in LessonCategories) {
            foreach (var lesson in category.Lessons) {
               Lessons.Add(lesson, category.Name);
            }
         }
      }

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            return Page();
         }

         if (SelectedLessonList == null) {
            return Page();
         }

         foreach (var option in SelectedLessonList) {
            var lesson = await context.Lessons.FirstOrDefaultAsync(l => l.Id.ToString() == option);
            if (lesson != null) {
               Skill.Lessons.Add(lesson);
            }
         }

         context.Skills.Add(Skill);
         await context.SaveChangesAsync();

         return RedirectToPage("./Index");
      }
   }
}
