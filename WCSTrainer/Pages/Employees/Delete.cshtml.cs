using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Employees {
  public class DeleteModel : PageModel {
    private readonly WCSTrainer.Data.WCSTrainerContext _context;

    public DeleteModel(WCSTrainer.Data.WCSTrainerContext context) {
      _context = context;
    }

    [BindProperty]
    public Employee Employee { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id) {
      if (id == null) {
        return NotFound();
      }

      var employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);

      if (employee == null) {
        return NotFound();
      } else {
        Employee = employee;
      }
      return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id) {
      if (id == null) {
        return NotFound();
      }

      var employee = await _context.Employees.FindAsync(id);
      if (employee != null) {
        Employee = employee;
        _context.Employees.Remove(Employee);
        await _context.SaveChangesAsync();
      }

      return RedirectToPage("./Index");
    }
  }
}
