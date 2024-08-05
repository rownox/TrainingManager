using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WCSTrainer.Pages.AccountManager {
   public class EditModel : PageModel {
      private readonly UserManager<UserAccount> _userManager;

      public EditModel(UserManager<UserAccount> userManager) {
         _userManager = userManager;
      }

      [BindProperty]
      public UserAccount User { get; set; }

      public async Task<IActionResult> OnGetAsync(string id) {
         User = await _userManager.FindByIdAsync(id);
         if (User == null) {
            return NotFound();
         }
         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         var user = await _userManager.FindByIdAsync(User.Id);
         if (user == null) {
            return NotFound();
         }

         user.Email = User.Email;

         var result = await _userManager.UpdateAsync(user);
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
