using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.Skills.Category {
   [Authorize(Roles = "owner, admin")]
   public class CreateModel(WCSTrainerContext context) : PageModel {
      [BindProperty]
      public SkillCategory SkillCategory { get; set; } = default!;

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            return Page();
         }

         context.SkillCategories.Add(SkillCategory);
         await context.SaveChangesAsync();

         return RedirectToPage("/Skills/Index");
      }
   }
}
