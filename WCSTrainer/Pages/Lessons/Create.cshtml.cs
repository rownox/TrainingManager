using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.Lessons {
   [Authorize(Roles = "owner, admin")]
   public class CreateModel(WCSTrainerContext context) : PageModel {
      [BindProperty]
      public Lesson Lesson { get; set; } = new Lesson();
      public SelectList CategorySelectList { get; set; }

      public async Task<IActionResult> OnGetAsync() {
         CategorySelectList = new SelectList(await context.LessonCategories.ToListAsync(), "Id", "Name");
         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            CategorySelectList = new SelectList(await context.LessonCategories.ToListAsync(), "Id", "Name");
            return Page();
         }
         context.Lessons.Add(Lesson);
         await context.SaveChangesAsync();
         return RedirectToPage("./Index");
      }
   }
}