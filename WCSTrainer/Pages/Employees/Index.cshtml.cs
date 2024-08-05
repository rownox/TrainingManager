using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Employees {
  public class IndexModel : PageModel {
    private readonly WCSTrainer.Data.WCSTrainerContext _context;

    public IndexModel(WCSTrainer.Data.WCSTrainerContext context) {
      _context = context;
    }

    public IList<Employee> Employees { get; set; } = default!;
    public IList<TrainerGroup> Groups { get; set; } = default!;

    public async Task OnGetAsync() {
      Employees = await _context.Employees.ToListAsync();
      Groups = await _context.TrainerGroups.ToListAsync();
    }
  }
}
