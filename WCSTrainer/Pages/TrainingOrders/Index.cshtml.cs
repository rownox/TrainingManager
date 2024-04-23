using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;
using WebApplication2.Models;

namespace WCSTrainer.Pages.TrainingOrders
{
    public class IndexModel : PageModel
    {
        private readonly WCSTrainer.Data.WCSTrainerContext _context;

        public IndexModel(WCSTrainer.Data.WCSTrainerContext context)
        {
            _context = context;
        }

        public IList<TrainingOrder> TrainingOrder { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TrainingOrder = await _context.TrainingOrder.ToListAsync();
        }
    }
}
