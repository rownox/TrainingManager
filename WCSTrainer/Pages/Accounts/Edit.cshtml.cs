using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Accounts {
   [Authorize(Roles = "owner")]
   public class EditModel(UserManager<UserAccount> userManager) : PageModel {

      [BindProperty]
      public UserAccount UserAccount { get; set; } = default!;

      public async Task<IActionResult> OnGetAsync(string id) {
         
         var newUser = await userManager.Users.FirstOrDefaultAsync(u => u.Id == id);

         if (newUser == null) {
            return Page();
         } else {
            UserAccount = newUser;
         }

         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         if (UserAccount == null) {
            return Page();
         }

         UserAccount.Email = UserAccount.Email;

         var result = await userManager.UpdateAsync(UserAccount);
         if (result.Succeeded) {
            return RedirectToPage("Index");
         }

         foreach (var error in result.Errors) {
            ModelState.AddModelError(string.Empty, error.Description);
         }

         return Page();
      }
   }
}
