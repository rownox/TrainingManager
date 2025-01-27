using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Lessons {
   public class DetailsModel(Data.WCSTrainerContext context) : PageModel {
      [BindProperty]
      public Lesson Lesson { get; set; } = default!;

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var lesson = await context.Lessons.FirstOrDefaultAsync(m => m.Id == id);

         if (lesson == null) {
            return NotFound();
         } else {
            Lesson = lesson;
         }

         return Page();
      }
   }
}
