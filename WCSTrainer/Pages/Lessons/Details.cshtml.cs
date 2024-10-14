using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Lessons {
   [Authorize(Roles = "admin, trainer")]
   public class DetailsModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public DetailsModel(WCSTrainer.Data.WCSTrainerContext context) {
         _context = context;
      }

      public Lesson Lesson { get; set; } = default!;

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var lesson = await _context.Lessons.FirstOrDefaultAsync(m => m.Id == id);
         if (lesson == null) {
            return NotFound();
         } else {
            Lesson = lesson;
         }
         return Page();
      }
   }
}
