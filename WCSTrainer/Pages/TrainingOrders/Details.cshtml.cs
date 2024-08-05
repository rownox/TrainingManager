using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.TrainingOrders {
   [Authorize(Roles = "admin, trainer, trainee")]
   public class DetailsModel : PageModel {
      private readonly WCSTrainerContext _context;

      public DetailsModel(WCSTrainerContext context) {
         _context = context;
      }

      public TrainingOrder TrainingOrder { get; set; } = default!;

      public async Task<IActionResult> OnGetAsync(int? id) {

         if (id == null) {
            return NotFound();
         }

         var trainingorder = await _context.TrainingOrders.FirstOrDefaultAsync(m => m.Id == id);
         if (trainingorder == null) {
            return NotFound();
         } else {
            TrainingOrder = trainingorder;
         }

         return Page();
      }
   }
}
