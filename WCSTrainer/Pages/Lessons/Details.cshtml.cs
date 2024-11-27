using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WCSTrainer.Pages.Lessons {
   [Authorize(Roles = "owner, admin, user, guest")]
   public class DetailsModel(Data.WCSTrainerContext context) : PageModel {
      [BindProperty]
      public Lesson Lesson { get; set; } = default!;

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var lesson = await context.Lessons
            .Include(l => l.Descriptions)
               .ThenInclude(d => d.ImageUpload)
            .FirstOrDefaultAsync(m => m.Id == id);

         if (lesson == null) {
            return NotFound();
         } else {
            Lesson = lesson;
         }

         return Page();
      }
   }
}
