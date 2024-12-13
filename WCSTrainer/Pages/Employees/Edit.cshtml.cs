using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Employees {
   [Authorize(Roles = "owner")]
   public class EditModel(WCSTrainer.Data.WCSTrainerContext context) : PageModel {
      [BindProperty]
      public Employee Employee { get; set; } = default!;

      public SelectList? Departments { get; set; }

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }
         Departments = new SelectList(await context.LessonCategories.ToListAsync(), "Id", "Name");

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
