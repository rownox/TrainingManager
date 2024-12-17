using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;
using WCSTrainer.Models;

namespace WCSTrainer.Pages.Locations {
   [Authorize(Roles = "owner, admin, user")]
   public class IndexModel(WCSTrainerContext context) : PageModel {
      public IList<Location> Locations { get; set; } = default!;
      public List<ListItem> ListItems { get; set; } = new List<ListItem>();
      public ListPartialModel? ListPartial { get; set; }
      [BindProperty]
      public int MaxCount { get; set; } = 10;
      public List<LocationCategory> CategoryList { get; set; }

      public async Task<IActionResult> OnGetAsync() {
         Locations = await context.Locations.ToListAsync();
         CategoryList = await context.LocationCategories
            .Include(c => c.Locations)
            .ToListAsync();

         MaxCount = MaxCount <= 0 ? 10 : MaxCount;
         foreach (var item in Locations) {
            ListItems.Add(
               new ListItem() {
                  Id = item.Id,
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
