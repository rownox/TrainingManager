using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace WCSTrainer.Pages.TrainingOrders {
   [Authorize(Roles = "owner, admin, user")]
   public class VerificationModel(WCSTrainer.Data.WCSTrainerContext context) : PageModel {
      [BindProperty]
      public TrainingOrder TrainingOrder { get; set; } = default!;

      [BindProperty]
      public string VerifyNotes { get; set; } = string.Empty;

      [BindProperty]
      public string Signature { get; set; } = string.Empty;

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var trainingorder = await context.TrainingOrders
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

         if (string.IsNullOrWhiteSpace(VerifyNotes)) {
            ModelState.AddModelError("VerifyNotes", "Please describe the training.");
            return await OnGetAsync(TrainingOrder.Id);
         }
         if (string.IsNullOrWhiteSpace(Signature)) {
            ModelState.AddModelError("Signature", "Please sign off the training.");
            return await OnGetAsync(TrainingOrder.Id);
         }

         if (!ModelState.IsValid) {
            return Page();
         }

         var trainingOrder = await context.TrainingOrders
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

         context.Verifications.Add(verification);

         trainingOrder.Status = "Verified";
         trainingOrder.Verification = verification;

         try {
            await context.SaveChangesAsync();
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
         return context.TrainingOrders.Any(e => e.Id == id);
      }
   }
}
