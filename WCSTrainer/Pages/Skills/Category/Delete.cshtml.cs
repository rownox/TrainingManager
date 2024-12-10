using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Skills.Category {
   [Authorize(Roles = "owner")]
   public class DeleteModel : PageModel {
      private readonly Data.WCSTrainerContext _context;

      public DeleteModel(Data.WCSTrainerContext context) {
         _context = context;
      }

      [BindProperty]
      public SkillCategory SkillCategory { get; set; } = default!;

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var category = await _context.SkillCategories.FirstOrDefaultAsync(m => m.Id == id);

         if (category == null) {
            return NotFound();
         } else {
            SkillCategory = category;
         }
         return Page();
      }

      public async Task<IActionResult> OnPostAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var category = await _context.SkillCategories.FindAsync(id);
         if (category != null) {
            SkillCategory = category;
            _context.SkillCategories.Remove(category);
            await _context.SaveChangesAsync();
         }

         return RedirectToPage("/Skills/Index");
      }
   }
}
