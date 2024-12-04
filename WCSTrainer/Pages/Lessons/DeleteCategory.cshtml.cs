using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Lessons {
   [Authorize(Roles = "owner")]
   public class DeleteCategoryModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public DeleteCategoryModel(WCSTrainer.Data.WCSTrainerContext context) {
         _context = context;
      }

      [BindProperty]
      public LessonCategory LessonCategory { get; set; } = default!;

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var lessonCategory = await _context.LessonCategories.FirstOrDefaultAsync(m => m.Id == id);

         if (lessonCategory == null) {
            return NotFound();
         } else {
            LessonCategory = lessonCategory;
         }
         return Page();
      }

      public async Task<IActionResult> OnPostAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var lessonCategory = await _context.LessonCategories.FindAsync(id);
         if (lessonCategory != null) {
            LessonCategory = lessonCategory;
            _context.LessonCategories.Remove(LessonCategory);
            await _context.SaveChangesAsync();
         }

         return RedirectToPage("./Index");
      }
   }
}
