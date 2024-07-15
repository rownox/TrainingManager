using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;
using WCSTrainer.Models;

namespace WCSTrainer.Pages.TrainingOrders {
    public class DetailsModel : PageModel {
        private readonly WCSTrainerContext _context;
        private readonly DataUtils _dataUtils;

        public DetailsModel(WCSTrainerContext context, DataUtils dataUtils) {
            _context = context;
            _dataUtils = dataUtils;
        }

        public TrainingOrder TrainingOrder { get; set; } = default!;
        public IList<Employee> Employees { get; set; }
        public Location Location { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id) {
            Employees = await _context.Employees.ToListAsync();

            if (id == null) {
                return NotFound();
            }

            var trainingorder = await _context.TrainingOrders.FirstOrDefaultAsync(m => m.Id == id);
            if (trainingorder == null) {
                return NotFound();
            } else {
                TrainingOrder = trainingorder;
            }

            var location = _dataUtils.GetLocationFromId(TrainingOrder.LocationId);
            if (location != null) {
                Location = location;
            }

            return Page();
        }
    }
}
