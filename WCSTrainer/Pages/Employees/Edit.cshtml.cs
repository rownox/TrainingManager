using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Employees {
   [Authorize(Roles = "owner")]
   public class EditModel(WCSTrainer.Data.WCSTrainerContext context) : PageModel {
      [BindProperty]
      public Employee Employee { get; set; } = default!;

      public List<LessonCategory> Departments { get; set; } = new List<LessonCategory>();
      [BindProperty]
      public List<string> SelectedDepartments { get; set; } = new List<string>();

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }
         Departments = await context.LessonCategories.ToListAsync();

         var employee = await context.Employees
             .Include(ua => ua.UserAccount)
             .Include(e => e.TrainerDepartments)
             .FirstOrDefaultAsync(m => m.Id == id);

         if (employee == null) {
            return NotFound();
         }
         Employee = employee;

         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            return Page();
         }

         context.Attach(Employee).State = EntityState.Modified;

         foreach (var option in SelectedDepartments) {
            var department = await context.LessonCategories.FirstOrDefaultAsync(l => l.Id.ToString() == option);
            if (department != null) {
               Employee.TrainerDepartments.Add(department);
            }
         }

         try {
            await context.SaveChangesAsync();
         } catch (DbUpdateConcurrencyException) {
            if (!EmployeeExists(Employee.Id)) {
               return NotFound();
            } else {
               throw;
            }
         }

         return RedirectToPage("./Index");
      }
      private bool EmployeeExists(int id) {
         return context.Employees.Any(e => e.Id == id);
      }
   }
}
