using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.TrainerGroups {
   public class CreateModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public CreateModel(WCSTrainer.Data.WCSTrainerContext context) {
         _context = context;
      }

      

      [BindProperty]
      public TrainerGroup TrainerGroup { get; set; } = default!;
      [BindProperty]
      public string SelectedEmployeeIds { get; set; } = default!;

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
            return Page();
         }

         _context.TrainerGroups.Add(TrainerGroup);
         await _context.SaveChangesAsync();

         return RedirectToPage("./Index");
      }
   }
}
