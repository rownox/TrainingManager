using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using System.Security.Claims;
using WCSTrainer.Models;

namespace WCSTrainer.Pages.TrainingOrders {
    [Authorize(Roles = "admin, trainer")]
    public class VerificationModel : PageModel {
        private readonly WCSTrainer.Data.WCSTrainerContext _context;

        public VerificationModel(WCSTrainer.Data.WCSTrainerContext context) {
            _context = context;
        }

        [BindProperty]
        public TrainingOrder TrainingOrder { get; set; } = default!;

        [BindProperty]
        public string VerifyNotes { get; set; }

        [BindProperty]
        public string Signature { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            var trainingorder = await _context.TrainingOrders
                .Include(t => t.Trainers)
                .Include(t => t.Location)
                .Include(t => t.Trainee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingorder == null) {
                return NotFound();
            }
            TrainingOrder = trainingorder;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            var trainingOrder = await _context.TrainingOrders
                .Include(t => t.Verification)
                .FirstOrDefaultAsync(t => t.Id == TrainingOrder.Id);

            if (trainingOrder == null) {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) {
                return Unauthorized();
            }

            var verification = new Verification {
                VerifyDate = DateOnly.FromDateTime(DateTime.Now),
                VerifyNotes = VerifyNotes,
                Signature = Signature,
                VerifierId = userId,
                TrainingOrderId = trainingOrder.Id
            };

            _context.Verifications.Add(verification);

            trainingOrder.Status = "Verified";
            trainingOrder.Verification = verification;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!TrainingOrderExists(TrainingOrder.Id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TrainingOrderExists(int id) {
            return _context.TrainingOrders.Any(e => e.Id == id);
        }
    }
}
