using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.Accounts {
   [Authorize(Roles = "owner, admin")]
   public class DetailsModel(UserManager<UserAccount> userManager, WCSTrainerContext context) : PageModel {
      [BindProperty]
      public UserAccount? UserAccount { get; set; }
      public Employee? Employee { get; set; }

      public async Task<IActionResult> OnGetAsync(string id) {
         UserAccount = await userManager.FindByIdAsync(id);

         if (UserAccount == null) {
            return NotFound();
         }

         Employee = await context.Employees
            .Include(e => e.TrainingOrdersAsTrainee)
            .Include(e => e.TrainingOrdersAsTrainer)
            .Include(e => e.Skills)
            .Include(e => e.Groups)
            .FirstOrDefaultAsync(e => e.Id == UserAccount.EmployeeId);

         return Page();
      }
   }
}
