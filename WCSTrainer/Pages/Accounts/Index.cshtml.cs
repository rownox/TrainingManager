using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.AccountManager {
   public class IndexModel(UserManager<UserAccount> userManager) : PageModel {
      public List<UserAccount> Users { get; set; } = default!;

      public async Task OnGetAsync() {
         Users = await userManager.Users.ToListAsync();
      }
   }
}
