using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Employees {
   [Authorize(Roles = "owner")]
   public class EditModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public EditModel(WCSTrainer.Data.WCSTrainerContext context) {
         _context = context;
      }

      [BindProperty]
      public Employee Employee { get; set; } = default!;

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var employee = await _context.Employees
             .Include(ua => ua.UserAccount)
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

         _context.Attach(Employee).State = EntityState.Modified;

         try {
            await _context.SaveChangesAsync();
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
         return _context.Employees.Any(e => e.Id == id);
      }
   }
}
