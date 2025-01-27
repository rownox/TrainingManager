using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace WCSTrainer.Pages.Help {
   public class IndexModel(Data.WCSTrainerContext context) : PageModel {
      public List<LessonCategory> CategoryList { get; set; } = new List<LessonCategory>();
      public async Task<IActionResult> OnGetAsync() {
         CategoryList = await context.LessonCategories
            .Include(c => c.Lessons)
            .ToListAsync();
         return Page();
      }

   }
}
