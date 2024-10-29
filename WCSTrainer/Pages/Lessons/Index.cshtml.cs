using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Models;

namespace WCSTrainer.Pages.Lessons {
   [Authorize(Roles = "owner, admin, user")]
   public class IndexModel(WCSTrainer.Data.WCSTrainerContext context) : PageModel {
      public IList<Lesson> Lessons { get; set; } = default!;

      public List<ListItem> ListItems { get; set; } = new List<ListItem>();
      public ListPartialModel? ListPartial { get; set; }
      [BindProperty]
      public int MaxCount { get; set; } = 10;

      public async Task<IActionResult> OnGetAsync() {
         Lessons = await context.Lessons
            .Include(l => l.TrainingOrders)
            .ToListAsync();

         MaxCount = MaxCount <= 0 ? 10 : MaxCount;
         foreach (var item in Lessons) {
            ListItems.Add(
               new ListItem() {
                  Id = item.Id,
                  Name = "Lesson #" + item.Id,
                  Description = item.Name
               }
            );
         }
         ListPartial = new ListPartialModel {
            Items = ListItems,
            MaxCount = MaxCount
         };

         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         return await OnGetAsync();
      }
   }
}
