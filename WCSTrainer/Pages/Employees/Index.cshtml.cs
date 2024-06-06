using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Models;

namespace WCSTrainer.Pages.Employees {
    public class IndexModel : PageModel {
        private readonly WCSTrainer.Data.WCSTrainerContext _context;

        public IndexModel(WCSTrainer.Data.WCSTrainerContext context) {
            _context = context;
        }

        public IList<Employee> Employee { get; set; } = default!;

        public async Task OnGetAsync() {
            Employee = await _context.Employee.ToListAsync();
        }
    }
}
