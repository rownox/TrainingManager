using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Lessons {
   [Authorize(Roles = "owner, admin")]
   public class CreateModel(Data.WCSTrainerContext context) : PageModel {
      [BindProperty]
      public Lesson Lesson { get; set; } = default!;
      public SelectList? CategroySelectList { get; set; }

      public async Task<IActionResult> OnGetAsync() {
         CategroySelectList = new SelectList(await context.LessonCategories.ToListAsync(), "Id", "Name");
         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            return Page();
         }

         context.Lessons.Add(Lesson);
         await context.SaveChangesAsync();

         return RedirectToPage("./Index");
      }
   }
}
