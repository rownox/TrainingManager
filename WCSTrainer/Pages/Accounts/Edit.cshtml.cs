using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WCSTrainer.Pages.Accounts {
   public class EditModel(UserManager<UserAccount> userManager) : PageModel {

      [BindProperty]
      public UserAccount? UserAccount { get; set; }

      public async Task<IActionResult> OnGetAsync(string id) {
         UserAccount = await userManager.FindByIdAsync(id);
         if (UserAccount == null) {
            return NotFound();
         }
         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         if (UserAccount == null) {
            return Page();
         }

         var user = await userManager.FindByIdAsync(UserAccount.Id);
         if (user == null) {
            return NotFound();
         }

         user.Email = UserAccount.Email;

         var result = await userManager.UpdateAsync(user);
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
