using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.TrainerGroups {
   [Authorize(Roles = "owner, admin, user")]
   public class DetailsModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public DetailsModel(WCSTrainer.Data.WCSTrainerContext context) {
         _context = context;
      }

      public TrainerGroup TrainerGroup { get; set; } = default!;

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var trainergroup = await _context.TrainerGroups
            .Include(t => t.TrainingOrders)
            .Include(t => t.Trainers)
            .FirstOrDefaultAsync(m => m.Id == id);
         if (trainergroup == null) {
            return NotFound();
         } else {
            TrainerGroup = trainergroup;
         }
         return Page();
      }
   }
}
