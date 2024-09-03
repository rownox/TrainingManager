using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using WCSTrainer.Data;

using Microsoft.AspNetCore.Identity;

namespace WCSTrainer.Pages.TrainingOrders {
   [Authorize(Roles = "admin, trainer")]
   public class CreateModel : PageModel {
      private readonly WCSTrainerContext _context;

      public CreateModel(WCSTrainerContext context) {
         _context = context;
      }

      [BindProperty]
      public TrainingOrder TrainingOrder { get; set; } = new TrainingOrder();
      [BindProperty]
      public IList<Employee> Employees { get; set; }
      public IList<TrainerGroup> TrainerGroups { get; set; }
      

      public async Task<IActionResult> OnGetAsync() {
         Employees = await _context.Employees.ToListAsync();
         TrainerGroups = await _context.TrainerGroups.ToListAsync();

         ViewData["EmployeesJson"] = System.Text.Json.JsonSerializer.Serialize(Employees ?? new List<Employee>());
         ViewData["TrainerGroupsJson"] = System.Text.Json.JsonSerializer.Serialize(TrainerGroups ?? new List<TrainerGroup>());

         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {

         if (!ModelState.IsValid) {
            await OnGetAsync();
            return Page();
         }

         _context.TrainingOrders.Add(TrainingOrder);
         await _context.SaveChangesAsync();

         return RedirectToPage("./Index");
      }
   }
}
