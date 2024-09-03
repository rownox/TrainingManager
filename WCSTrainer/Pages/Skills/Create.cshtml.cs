using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Skills {
   public class CreateModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public CreateModel(WCSTrainer.Data.WCSTrainerContext context) {
         _context = context;
      }

      [BindProperty]
      public Skill Skill { get; set; } = default!;
      [BindProperty]
      public string? LessonString { get; set; }

      public IActionResult OnGet() {
         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         //if (!ModelState.IsValid) {
         //   return Page();
         //}

         _context.Skills.Add(Skill);
         await _context.SaveChangesAsync();

         if (LessonString != null) {
            var lessonIds = LessonString.Split(", ").Select(int.Parse).ToList();

            Skill.Lessons = await _context.Lessons
                .Where(e => lessonIds.Contains(e.Id))
                .ToListAsync();
         }

         _context.Skills.Update(Skill);
         await _context.SaveChangesAsync();

         return RedirectToPage("./Index");
      }
   }
}
