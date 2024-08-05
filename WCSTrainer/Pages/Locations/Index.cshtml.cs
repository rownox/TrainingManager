using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.Locations {
  public class IndexModel : PageModel {
    private readonly WCSTrainerContext _context;

    public IndexModel(WCSTrainerContext context) {
      _context = context;
    }

    public IList<Location> Location { get; set; } = default!;

    public async Task OnGetAsync() {
      Location = await _context.Locations.ToListAsync();
    }
  }
}
