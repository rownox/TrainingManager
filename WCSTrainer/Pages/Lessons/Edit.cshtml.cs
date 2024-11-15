using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Lessons {
   [Authorize(Roles = "owner, admin")]
   public class EditModel(WCSTrainer.Data.WCSTrainerContext context) : PageModel {
      [BindProperty]
      public Lesson Lesson { get; set; } = default!;

      public SelectList CategorySelectList { get; set; }

      public async Task<IActionResult> OnGetAsync(int? id) {
         CategorySelectList = new SelectList(await context.LessonCategories.ToListAsync(), "Id", "Name");

         if (id == null) {
            return NotFound();
         }

         var lesson = await context.Lessons.FirstOrDefaultAsync(m => m.Id == id);
         if (lesson == null) {
            return NotFound();
         }
         Lesson = lesson;
         ViewData["TrainingOrderId"] = new SelectList(context.TrainingOrders, "Id", "Id");
         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            return Page();
         }

         context.Attach(Lesson).State = EntityState.Modified;

         try {
            await context.SaveChangesAsync();
         } catch (DbUpdateConcurrencyException) {
            if (!LessonExists(Lesson.Id)) {
               return NotFound();
            } else {
               throw;
            }
         }

         return RedirectToPage("./Index");
      }

      private bool LessonExists(int id) {
         return context.Lessons.Any(e => e.Id == id);
      }
   }
}
