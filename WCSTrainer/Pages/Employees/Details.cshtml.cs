using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.Accounts.Employees {
   [Authorize(Roles = "owner, admin, user")]
   public class DetailsModel(WCSTrainerContext context) : PageModel {

      [BindProperty]
      public Employee Employee { get; set; } = default!;

      public async Task<IActionResult> OnGetAsync(int? id) {
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