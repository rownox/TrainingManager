using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.Locations {
   [Authorize(Roles = "owner, admin")]
   public class CreateCategoryModel(WCSTrainerContext context) : PageModel {
      [BindProperty]
      public LocationCategory LocationCategory { get; set; } = default!;

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            return Page();
         }

         context.LocationCategories.Add(LocationCategory);
         await context.SaveChangesAsync();
         return RedirectToPage("./Index");
      }
   }
}
