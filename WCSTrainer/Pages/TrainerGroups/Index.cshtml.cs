using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.TrainerGroups
{
    public class IndexModel : PageModel
    {
        private readonly WCSTrainer.Data.WCSTrainerContext _context;

        public IndexModel(WCSTrainer.Data.WCSTrainerContext context)
        {
            _context = context;
        }

        public IList<TrainerGroup> TrainerGroup { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TrainerGroup = await _context.TrainerGroups.ToListAsync();
        }
    }
}
