using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.Accounts
{
    public class AccountsModel : PageModel
    {
        private readonly WCSTrainerContext _context;

        public AccountsModel(WCSTrainerContext context) {
            _context = context;
        }

        public List<UserAccount> Users { get; set; }
        public async Task<IActionResult> OnGetAsync() {

            Users = await _context.Users.ToListAsync();

            return Page();
        }
    }
}
