using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.Locations.Category {
   [Authorize(Roles = "owner, admin")]
   public class CreateModel(WCSTrainerContext context) : PageModel {
      [BindProperty]
      public LocationCategory Category { get; set; } = default!;

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            return Page();
         }

         context.LocationCategories.Add(Category);
         await context.SaveChangesAsync();

         return RedirectToPage("/Lessons/Index");
      }
   }
}
