using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.TrainerGroups {
   [Authorize(Roles = "owner, admin")]
   public class CreateModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public CreateModel(WCSTrainer.Data.WCSTrainerContext context) {
         _context = context;
      }

      [BindProperty]
      public TrainerGroup TrainerGroup { get; set; } = default!;
      [BindProperty]
      public string SelectedEmployeeIdString { get; set; } = default!;
      public IList<Employee> Employees { get; set; }

      public async Task<IActionResult> OnGetAsync() {
         Employees = await _context.Employees
            .Include(e => e.TrainerDepartments)
            .ToListAsync();
         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            Employees = await _context.Employees.ToListAsync();
            return Page();
         }

         if (SelectedEmployeeIdString != null) {
            var SelectedEmployeeIds = SelectedEmployeeIdString.Split(", ").Select(int.Parse).ToList();
            TrainerGroup.Trainers = await _context.Employees
               .Where(e => SelectedEmployeeIds.Contains(e.Id))
               .ToListAsync();
         }

         _context.TrainerGroups.Add(TrainerGroup);
         await _context.SaveChangesAsync();

         return RedirectToPage("./Index");
      }
   }
}
