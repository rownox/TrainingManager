using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Locations {
   [Authorize(Roles = "owner, admin")]
   public class EditModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public EditModel(WCSTrainer.Data.WCSTrainerContext context) {
         _context = context;
      }

      [BindProperty]
      public Location Location { get; set; } = default!;

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var location = await _context.Locations.FirstOrDefaultAsync(m => m.Id == id);
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

         _context.Attach(Location).State = EntityState.Modified;

         try {
            await _context.SaveChangesAsync();
         } catch (DbUpdateConcurrencyException) {
            if (!LocationExists(Location.Id)) {
               return NotFound();
            } else {
               throw;
            }
         }

         return RedirectToPage("./Index");
      }

      private bool LocationExists(int id) {
         return _context.Locations.Any(e => e.Id == id);
      }
   }
}
