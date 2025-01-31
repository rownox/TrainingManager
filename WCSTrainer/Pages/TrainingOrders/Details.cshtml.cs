using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;
using WCSTrainer.Helpers;

namespace WCSTrainer.Pages.TrainingOrders {
   [Authorize(Roles = "owner, admin, user, guest")]
   public class DetailsModel(WCSTrainerContext context, UserManager<UserAccount> userManager) : PageModel {
      [BindProperty]
      public TrainingOrder TrainingOrder { get; set; } = default!;

      public async Task<IActionResult> OnGetAsync(int? id) {

         if (id == null) {
            return NotFound();
         }

         var trainingorder = await context.TrainingOrders
            .Include(to => to.Trainee)
            .Include(to => to.Lesson)
            .FirstOrDefaultAsync(m => m.Id == id);
         if (trainingorder == null) {
            return NotFound();
         } else {
            TrainingOrder = trainingorder;
         }

         if (!TrainingOrderHelper.HasPerms(userManager, User, context, TrainingOrder).Result) {
            return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
         }

         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {

         var newTrainingOrder = await context.TrainingOrders.FirstOrDefaultAsync(m => m.Id == TrainingOrder.Id);
         if (newTrainingOrder == null) {
            return NotFound();
         }

         newTrainingOrder.Archived = !newTrainingOrder.Archived;
         context.Entry(newTrainingOrder).State = EntityState.Modified;

         await context.SaveChangesAsync();
         return RedirectToPage("./Index");
      }
   }
}
