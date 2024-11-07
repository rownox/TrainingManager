using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WCSTrainer.Models;

namespace WCSTrainer.Pages.Skills {
   [Authorize(Roles = "owner, admin, user")]
   public class IndexModel(WCSTrainer.Data.WCSTrainerContext context) : PageModel {
      public IList<Skill> Skills { get; set; } = default!;
      public List<ListItem> ListItems { get; set; } = new List<ListItem>();
      public List<SkillCategory> SkillCategories { get; set; } = new List<SkillCategory>();
      public ListPartialModel ListPartial { get; set; }
      [BindProperty]
      public int MaxCount { get; set; } = 10;

      public string? CategoryName { get; set; }

      public async Task<IActionResult> OnGetAsync() {
         Skills = await context.Skills.ToListAsync();
         SkillCategories = await context.SkillCategories.ToListAsync();

         MaxCount = MaxCount <= 0 ? 10 : MaxCount;

         foreach (var skill in Skills) {
            ListItems.Add(
               new ListItem() {
                  Id = skill.Id,
                  Name = "Skill #" + skill.Id,
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
         if (!ModelState.IsValid) {
            return Page();
         }

         if (CategoryName.IsNullOrEmpty()) {
            return Page();
         } else {
            var skillCategory = new SkillCategory() {
               Name = CategoryName
            };
            context.SkillCategories.Add(skillCategory);
            await context.SaveChangesAsync();
         }
         
         return await OnGetAsync();
      }
   }
}
