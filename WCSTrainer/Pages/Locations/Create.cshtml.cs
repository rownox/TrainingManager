using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Locations {
   [Authorize(Roles = "owner, admin")]
   public class CreateModel(Data.WCSTrainerContext context) : PageModel {
      public SelectList CategorySelectList { get; set; }

      public async Task<IActionResult> OnGetAsync() {
         CategorySelectList = new SelectList(await context.LocationCategories.ToListAsync(), "Id", "Name");

         return Page();
      }

      [BindProperty]
      public Location Location { get; set; } = default!;

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            return Page();
         }

         context.Locations.Add(Location);
         await context.SaveChangesAsync();

         return RedirectToPage("./Index");
      }
   }
}
