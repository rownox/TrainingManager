using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Locations.Category {
   [Authorize(Roles = "owner")]
   public class DeleteModel : PageModel {
      private readonly Data.WCSTrainerContext _context;

      public DeleteModel(Data.WCSTrainerContext context) {
         _context = context;
      }

      [BindProperty]
      public LocationCategory Category { get; set; } = default!;

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var category = await _context.LocationCategories.FirstOrDefaultAsync(m => m.Id == id);

         if (category == null) {
            return NotFound();
         } else {
            Category = category;
         }
         return Page();
      }

      public async Task<IActionResult> OnPostAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var category = await _context.LocationCategories.FindAsync(id);
         if (category != null) {
            Category = category;
            _context.LocationCategories.Remove(category);
            await _context.SaveChangesAsync();
         }

         return RedirectToPage("/Locations/Index");
      }
   }
}
