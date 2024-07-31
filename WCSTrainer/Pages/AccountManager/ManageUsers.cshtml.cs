using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.AccountManager
{
    public class ManageUsersModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ManageUsersModel(UserManager<IdentityUser> userManager) {
            _userManager = userManager;
        }

        public List<IdentityUser> Users { get; set; }

        public async Task OnGetAsync() {
            Users = await _userManager.Users.ToListAsync();
        }
    }
}
