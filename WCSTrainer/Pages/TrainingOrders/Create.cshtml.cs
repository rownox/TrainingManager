using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WCSTrainer.Data;
using WCSTrainer.Models;
using WebApplication2.Models;

namespace WCSTrainer.Pages.TrainingOrders {
    public class CreateModel : PageModel {
        private readonly WCSTrainerContext _context;
        private readonly EmployeeContext _context2;

        public CreateModel(WCSTrainerContext context, EmployeeContext context2) {
            _context = context;
            _context2 = context2;
        }

        public async Task<IActionResult> OnGetAsync() {
            Employees = await _context2.Employee.ToListAsync();
            return Page();
        }

        [BindProperty]
        public TrainingOrder TrainingOrder { get; set; } = new TrainingOrder();

        public DateOnly Day { get; } = DateOnly.FromDateTime(DateTime.Now);

        public IList<Employee> Employees { get; set; }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            _context.TrainingOrder.Add(TrainingOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
