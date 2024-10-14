using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.TrainerGroups {
   [Authorize(Roles = "owner, admin, user")]
   public class IndexModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public IndexModel(WCSTrainer.Data.WCSTrainerContext context) {
         _context = context;
      }

      public IList<TrainerGroup> TrainerGroup { get; set; } = default!;

      public async Task OnGetAsync() {
         TrainerGroup = await _context.TrainerGroups.ToListAsync();
      }


   }
}
