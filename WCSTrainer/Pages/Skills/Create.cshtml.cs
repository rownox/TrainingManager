using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Skills {
   public class CreateModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public CreateModel(WCSTrainer.Data.WCSTrainerContext context) {
         _context = context;
      }

      [BindProperty]
      public Skill Skill { get; set; } = default!;
      [BindProperty]
      public string? TrainingOrdersString { get; set; }

      public IActionResult OnGet() {
         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            return Page();
         }

         _context.Skills.Add(Skill);
         await _context.SaveChangesAsync();

         if (TrainingOrdersString != null) {
            var trainingOrderIds = TrainingOrdersString.Split(", ").Select(int.Parse).ToList();

            Skill.TrainingOrders = await _context.TrainingOrders
                .Where(e => trainingOrderIds.Contains(e.Id))
                .ToListAsync();
         }

         _context.Skills.Update(Skill);
         await _context.SaveChangesAsync();

         return RedirectToPage("./Index");
      }
   }
}
