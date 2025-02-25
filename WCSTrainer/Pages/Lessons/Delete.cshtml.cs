using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Lessons {
   [Authorize(Roles = "owner, admin")]
   public class DeleteModel : PageModel {
      private readonly Data.WCSTrainerContext _context;

      public DeleteModel(Data.WCSTrainerContext context) {
         _context = context;
      }

      [BindProperty]
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

      public async Task<IActionResult> OnPostAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var lesson = await _context.Lessons.FindAsync(id);
         if (lesson != null) {
            Lesson = lesson;
            _context.Lessons.Remove(Lesson);
            await _context.SaveChangesAsync();
         }

         return RedirectToPage("./Index");
      }
   }
}
