using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.Lessons {
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
