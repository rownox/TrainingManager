using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.Lessons.Category {
   [Authorize(Roles = "owner, admin")]
   public class CreateModel(WCSTrainerContext context) : PageModel {
      [BindProperty]
      public LessonCategory Category { get; set; } = default!;

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            return Page();
         }

         context.LessonCategories.Add(Category);
         await context.SaveChangesAsync();

         return RedirectToPage("/Lessons/Index");
      }
   }
}
