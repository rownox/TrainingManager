using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.TrainingOrders {
   [Authorize(Roles = "owner, admin, user, guest")]
   public class IndexModel(Data.WCSTrainerContext context) : PageModel {

      public IList<TrainingOrder> TrainingOrder { get; set; } = default!;
      public IList<Employee> Employees { get; set; } = default!;
      public int listCount = 0;
      [BindProperty]
      public int MaxCount { get; set; } = 10;
      [BindProperty]
      public bool Detailed { get; set; } = false;

      public async Task<IActionResult> OnGetAsync() {
         if (TempData.ContainsKey("Detailed")) {
            Detailed = (bool)TempData["Detailed"];
         }
         if (TempData.ContainsKey("MaxCount")) {
            MaxCount = (int)TempData["MaxCount"];
         }

         await LoadData();
         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         TempData["Detailed"] = Detailed;
         TempData["MaxCount"] = MaxCount;

         return RedirectToPage();
      }

      public async Task LoadData() {
         Employees = await context.Employees.ToListAsync();
         TrainingOrder = await context.TrainingOrders
            .Include(t => t.Trainers)
            .Include(t => t.ParentSkill)
            .Include(t => t.Lesson)
            .ToListAsync();
      }
   }
}
