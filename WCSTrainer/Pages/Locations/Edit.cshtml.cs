using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Locations {
   [Authorize(Roles = "owner, admin")]
   public class EditModel(WCSTrainer.Data.WCSTrainerContext context) : PageModel {
      [BindProperty]
      public Location Location { get; set; } = default!;

      public SelectList CategorySelectList { get; set; }

      public async Task<IActionResult> OnGetAsync(int? id) {
         CategorySelectList = new SelectList(await context.LocationCategories.ToListAsync(), "Id", "Name");

         if (id == null) {
            return NotFound();
         }

         var location = await context.Locations.FirstOrDefaultAsync(m => m.Id == id);
         if (location == null) {
            return NotFound();
         }
         Location = location;
         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            return Page();
         }

         context.Attach(Location).State = EntityState.Modified;

         try {
            await context.SaveChangesAsync();
         } catch (DbUpdateConcurrencyException) {
            if (!LocationExists(Location.Id)) {
               return NotFound();
            } else {
               throw;
            }
         }

         return RedirectToPage("/Locations/Details", new { Location.Id });
      }

      private bool LocationExists(int id) {
         return context.Locations.Any(e => e.Id == id);
      }
   }
}
