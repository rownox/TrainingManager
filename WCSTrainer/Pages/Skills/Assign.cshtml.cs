using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.Skills {
   public class AssignModel : PageModel {

      private readonly WCSTrainerContext _context;
      public AssignModel(WCSTrainerContext context) {
         _context = context;
      }

      public Skill Skill { get; set; } = default!;

      [BindProperty]
      public IList<Employee> Employees { get; set; }

      [BindProperty]
      public string? SelectedTrainerString { get; set; }
      public List<int> SelectedTrainerIds { get; set; } = new List<int>();
      [BindProperty]
      public string? SelectedTrainerGroupString { get; set; }
      public List<int> SelectedTrainerGroupIds { get; set; } = new List<int>();

      public int SelectedTraineeId { get; set; }


      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var skill = await _context.Skills
             .Include(s => s.Employees)
             .Include(s => s.TrainingOrders)
             .FirstOrDefaultAsync(m => m.Id == id);
         if (skill == null) {
            return NotFound();
         } else {
            Skill = skill;

         }

         Employees = await _context.Employees.ToListAsync();
         ViewData["EmployeesJson"] = System.Text.Json.JsonSerializer
             .Serialize(Employees ?? new List<Employee>());

         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {




         return Page();
      }
   }
}
