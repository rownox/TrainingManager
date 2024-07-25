using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.TrainerGroups {
    public class IndexModel : PageModel {
        private readonly WCSTrainer.Data.WCSTrainerContext _context;

        public IndexModel(WCSTrainer.Data.WCSTrainerContext context) {
            _context = context;
        }

        public IList<TrainerGroup> TrainerGroup { get; set; } = default!;

        public async Task OnGetAsync() {
            TrainerGroup = await _context.TrainerGroups.ToListAsync();
        }
    }
}
