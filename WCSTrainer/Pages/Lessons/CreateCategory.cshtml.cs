using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.Lessons {
   [Authorize(Roles = "owner, admin")]
   public class CreateCategoryModel(WCSTrainerContext context) : PageModel {
      [BindProperty]
      public LessonCategory LessonCategory { get; set; } = default!;

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            return Page();
         }

         context.LessonCategories.Add(LessonCategory);
         await context.SaveChangesAsync();
         return RedirectToPage("./Index");
      }
   }
}
