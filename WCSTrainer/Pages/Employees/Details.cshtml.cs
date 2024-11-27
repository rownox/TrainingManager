using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;
using WCSTrainer.Helpers;

namespace WCSTrainer.Pages.Accounts.Employees {
   [Authorize(Roles = "owner, admin, user, guest")]
   public class DetailsModel(WCSTrainerContext context, UserManager<UserAccount> userManager) : PageModel {

      [BindProperty]
      public Employee Employee { get; set; } = default!;

      public async Task<IActionResult> OnGetAsync(int? id) {

         if (!EmployeeHelper.hasPerms(id, userManager, User).Result) {
            return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
         }

         var tempEmployee = await context.Employees.FirstOrDefaultAsync(a => a.Id == id);

         if (tempEmployee != null) {
            Employee = tempEmployee;
         } else {
            return NotFound();
         }
         return Page();
      }
   }
}