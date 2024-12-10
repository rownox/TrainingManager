using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.Locations.Category {
   [Authorize(Roles = "owner, admin")]
   public class EditModel(WCSTrainerContext context) : PageModel {
      [BindProperty]
      public LocationCategory? Category { get; set; }

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var category = await context.LocationCategories.FirstOrDefaultAsync(m => m.Id == id);
         if (category == null) {
            return NotFound();
         }

         Category = category;
         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            return Page();
         }

         if (Category != null) {
            context.LocationCategories.Update(Category);
            await context.SaveChangesAsync();
         }

         return RedirectToPage("/Lessons/Index");
      }
   }
}
