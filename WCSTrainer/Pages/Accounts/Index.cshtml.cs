using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.AccountManager {
  public class IndexModel : PageModel {
    private readonly UserManager<UserAccount> _userManager;

    public IndexModel(UserManager<UserAccount> userManager) {
      _userManager = userManager;
    }

    public List<UserAccount> Users { get; set; }

    public async Task OnGetAsync() {
      Users = await _userManager.Users.ToListAsync();
    }
  }
}
