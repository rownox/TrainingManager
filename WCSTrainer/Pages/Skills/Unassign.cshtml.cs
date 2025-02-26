using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.Skills {
   [Authorize(Roles = "owner, admin")]
   public class UnassignModel(WCSTrainerContext context) : PageModel {

      [BindProperty]
      public Skill Skill { get; set; } = default!;
      [BindProperty]
      public int SelectedTraineeId { get; set; }
      [BindProperty]
      public IList<Employee>? Employees { get; set; }
      public List<Employee> assignedEmployees = new List<Employee>();

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var skill = await context.Skills
             .Include(s => s.Employees)
             .Include(s => s.Lessons)
             .FirstOrDefaultAsync(m => m.Id == id);

         if (skill == null) {
            return NotFound();
         }

         Skill = skill;
         Employees = await context.Employees
            .Include(e => e.Skills)
            .Include(e => e.TrainerDepartments)
            .ToListAsync();

         foreach (var employee in Employees) {
            if (Skill.Employees.Any(e => e.Id == employee.Id)) {
               assignedEmployees.Add(employee);
            }
         }

         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            return OnGetAsync(Skill.Id).Result;
         }

         var trainee = await context.Employees
             .Include(t => t.TrainingOrdersAsTrainee)
             .Include(t => t.Skills)
             .FirstOrDefaultAsync(e => e.Id == SelectedTraineeId);

         if (trainee == null) {
            ModelState.AddModelError("", "Selected trainee not found.");
            return OnGetAsync(Skill.Id).Result;
         }

         var skill = await context.Skills
             .Include(s => s.Employees)
             .Include(s => s.TrainingOrders)
             .FirstOrDefaultAsync(m => m.Id == Skill.Id);

         if (skill != null) {
            if (skill.Employees.Any(e => e.Id == trainee.Id)) {
               var ordersToRemove = trainee.TrainingOrdersAsTrainee
                  .Where(to => to.ParentSkillId == Skill.Id)
                  .ToList();

               context.TrainingOrders.RemoveRange(ordersToRemove);
               skill.Employees.Remove(trainee);
               trainee.Skills.Remove(skill);
               await context.SaveChangesAsync();
               return RedirectToPage("./Index");
            } else {
               ModelState.AddModelError("", "The skill is not assigned to this user.");
               return OnGetAsync(Skill.Id).Result;
            }
         }

         return OnGetAsync(Skill.Id).Result;
      }
   }
}
