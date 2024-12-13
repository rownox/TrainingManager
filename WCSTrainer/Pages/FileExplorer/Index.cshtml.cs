using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WCSTrainer.Pages.FileManager {
   [Authorize(Roles = "owner, admin")]
   public class IndexModel : PageModel {

      public void OnGet() {
      }
   }
}
