using AngleSharp.Dom;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;
using WCSTrainer.Models;

namespace WCSTrainer.Pages.TrainingOrders {
    public class DetailsModel : PageModel {
        private readonly WCSTrainerContext _context;

        public DetailsModel(WCSTrainerContext context) {
            _context = context;
        }

        public TrainingOrder TrainingOrder { get; set; } = default!;
        public string TrainerList;

        public async Task<IActionResult> OnGetAsync(int? id) {

            if (id == null) {
                return NotFound();
            }

            var trainingorder = await _context.TrainingOrders
                .Include(t => t.Trainee)
                .Include(l => l.Location)
                .Include(tr => tr.Trainers)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (trainingorder == null) {
                return NotFound();
            } else {
                TrainingOrder = trainingorder;
            }

            List<string> trainerNames = new List<string>();

            foreach(var trainer in TrainingOrder.Trainers) {
                trainerNames.Add(trainer.FirstName + " " + trainer.LastName);
            }

            TrainerList = string.Join(", ", trainerNames);

            return Page();
        }
    }
}
