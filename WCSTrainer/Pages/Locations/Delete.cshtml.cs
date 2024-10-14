using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Locations {
   [Authorize(Roles = "admin, trainer")]
   public class DeleteModel(Data.WCSTrainerContext context) : PageModel {

      [BindProperty]
      public Location Location { get; set; } = default!;

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var location = await context.Locations.FirstOrDefaultAsync(m => m.Id == id);
         if (location == null) {
            return NotFound();
         } else {
            Location = location;
         }
         return Page();
      }

      public async Task<IActionResult> OnPostAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var location = await context.Locations.FindAsync(id);
         if (location != null) {
            Location = location;
            context.Locations.Remove(Location);
            await context.SaveChangesAsync();
         }

         return RedirectToPage("./Index");
      }
   }
}
