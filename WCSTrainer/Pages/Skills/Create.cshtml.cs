using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WCSTrainer.Pages.Skills {
   public class CreateModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public CreateModel(WCSTrainer.Data.WCSTrainerContext context) {
         _context = context;
      }

      public IActionResult OnGet() {
         return Page();
      }

      [BindProperty]
      public Skill Skill { get; set; } = default!;

      // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            return Page();
         }

         _context.Skills.Add(Skill);
         await _context.SaveChangesAsync();

         return RedirectToPage("./Index");
      }
   }
}
