using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Lessons {
   [Authorize(Roles = "owner, admin, user")]
   public class IndexModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public IndexModel(WCSTrainer.Data.WCSTrainerContext context) {
         _context = context;
      }

      public IList<Lesson> Lesson { get; set; } = default!;

      public async Task OnGetAsync() {
         Lesson = await _context.Lessons
            .Include(l => l.TrainingOrders)
            .ToListAsync();
      }
   }
}
