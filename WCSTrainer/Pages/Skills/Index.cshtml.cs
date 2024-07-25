using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Skills {
    public class IndexModel : PageModel {
        private readonly WCSTrainer.Data.WCSTrainerContext _context;

        public IndexModel(WCSTrainer.Data.WCSTrainerContext context) {
            _context = context;
        }

        public IList<Skill> Skill { get; set; } = default!;

        public async Task OnGetAsync() {
            Skill = await _context.Skills.ToListAsync();
        }
    }
}
