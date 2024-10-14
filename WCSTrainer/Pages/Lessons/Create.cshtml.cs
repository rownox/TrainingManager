using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WCSTrainer.Pages.Lessons {
   [Authorize(Roles = "owner, admin")]
   public class CreateModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public CreateModel(WCSTrainer.Data.WCSTrainerContext context) {
         _context = context;
      }

      public IActionResult OnGet() {
         ViewData["TrainingOrderId"] = new SelectList(_context.TrainingOrders, "Id", "Id");
         return Page();
      }

      [BindProperty]
      public Lesson Lesson { get; set; } = default!;

      // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            return Page();
         }

         _context.Lessons.Add(Lesson);
         await _context.SaveChangesAsync();

         return RedirectToPage("./Index");
      }
   }
}
