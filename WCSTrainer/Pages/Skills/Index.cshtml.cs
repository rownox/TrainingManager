using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Models;

namespace WCSTrainer.Pages.Skills {
   [Authorize(Roles = "owner, admin, user")]
   public class IndexModel(WCSTrainer.Data.WCSTrainerContext context) : PageModel {
      public IList<Skill> Skills { get; set; } = default!;
      public List<ListItem> ListItems { get; set; } = new List<ListItem>();
      public ListPartialModel ListPartial { get; set; }
      [BindProperty]
      public int MaxCount { get; set; } = 10;
      public List<SkillCategory> CategoryList { get; set; }

      public async Task<IActionResult> OnGetAsync() {
         Skills = await context.Skills.ToListAsync();
         CategoryList = await context.SkillCategories
            .Include(c => c.Skills)
            .ToListAsync();

         MaxCount = MaxCount <= 0 ? 10 : MaxCount;

         foreach (var skill in Skills) {
            ListItems.Add(
               new ListItem() {
                  Id = skill.Id,
                  Description = skill.Name
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
