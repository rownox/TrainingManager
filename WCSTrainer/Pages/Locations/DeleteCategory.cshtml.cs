using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Locations {
   [Authorize(Roles = "owner")]
   public class DeleteCategoryModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public DeleteCategoryModel(WCSTrainer.Data.WCSTrainerContext context) {
         _context = context;
      }

      [BindProperty]
      public LocationCategory LocationCategory { get; set; } = default!;

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var category = await _context.LocationCategories.FirstOrDefaultAsync(m => m.Id == id);

         if (category == null) {
            return NotFound();
         } else {
            LocationCategory = category;
         }
         return Page();
      }

      public async Task<IActionResult> OnPostAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var category = await _context.LocationCategories.FindAsync(id);
         if (category != null) {
            LocationCategory = category;
            _context.LocationCategories.Remove(LocationCategory);
            await _context.SaveChangesAsync();
         }

         return RedirectToPage("./Index");
      }
   }
}
