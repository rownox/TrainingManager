using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WCSTrainer.Pages {
  public class IndexModel : PageModel {
    private readonly ILogger<IndexModel> _logger;

    private readonly WCSTrainer.Data.WCSTrainerContext _context;

    public IndexModel(ILogger<IndexModel> logger, WCSTrainer.Data.WCSTrainerContext context) {
      _logger = logger;
      _context = context;
    }

    public void OnGet() {

    }
  }
}
