using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Skills {
   [Authorize(Roles = "admin, trainer")]
   public class IndexModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public IndexModel(WCSTrainer.Data.WCSTrainerContext context) {
         _context = context;
      }

      public IList<Skill> Skills { get; set; } = default!;

      public int listCount = 0;
      [BindProperty]
      public int maxCount { get; set; } = 10;

      public async Task OnGetAsync() {
         Skills = await _context.Skills.ToListAsync();
      }
   }
}
