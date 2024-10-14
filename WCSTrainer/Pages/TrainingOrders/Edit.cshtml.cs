using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.TrainingOrders {
   [Authorize(Roles = "owner, admin, user")]
   public class EditModel(WCSTrainerContext context) : PageModel {

      [BindProperty]
      public TrainingOrder TrainingOrder { get; set; } = default!;
      [BindProperty]
      public IList<Employee>? Employees { get; set; }
      [BindProperty]
      public IList<TrainerGroup>? TrainerGroups { get; set; }
      public SelectList? Locations { get; set; }
      [BindProperty]
      public string? SelectedTrainerString { get; set; }
      public List<int> SelectedTrainerIds { get; set; } = new List<int>();
      [BindProperty]
      public string? SelectedTrainerGroupString { get; set; }
      public List<int> SelectedTrainerGroupIds { get; set; } = new List<int>();

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         await initJson();

         var newOrder = initOrder(id).Result;
         if (newOrder != null) {
            TrainingOrder = newOrder;
         }

         foreach (var trainer in TrainingOrder.Trainers) {
            SelectedTrainerIds.Add(trainer.Id);
         }
         SelectedTrainerIds = TrainingOrder.Trainers.Select(t => t.Id).ToList();
         SelectedTrainerString = string.Join(", ", SelectedTrainerIds);

         foreach (var trainerGroup in TrainingOrder.TrainerGroups) {
            SelectedTrainerGroupIds.Add(trainerGroup.Id);
         }
         SelectedTrainerGroupIds = TrainingOrder.TrainerGroups.Select(tg => tg.Id).ToList();
         SelectedTrainerGroupString = string.Join(", ", SelectedTrainerGroupIds);

         Locations = new SelectList(await context.Locations.ToListAsync(), "Id", "Name");

         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {

         if (TrainingOrder.Status != "Awaiting Approval") {
            if (string.IsNullOrWhiteSpace(SelectedTrainerGroupString) && string.IsNullOrWhiteSpace(SelectedTrainerString)) {
               ModelState.AddModelError("SelectedTrainerString", "At least one trainer or trainer group must be selected.");
               await initJson();

               return await OnGetAsync(TrainingOrder.Id);
            }
         }

         if (!ModelState.IsValid) {
            await initJson();

            return await OnGetAsync(TrainingOrder.Id);
         }

         context.Attach(TrainingOrder).State = EntityState.Modified;
         var trainingOrderToUpdate = await context.TrainingOrders
             .Include(t => t.Trainers)
             .Include(t => t.TrainerGroups)
             .FirstOrDefaultAsync(t => t.Id == TrainingOrder.Id);

         if (trainingOrderToUpdate == null) {
            return NotFound();
         }

         context.Entry(trainingOrderToUpdate).CurrentValues.SetValues(TrainingOrder);
         if (SelectedTrainerString != null) {
            List<int> newTrainerIds = SelectedTrainerString.Split(", ").Select(int.Parse).ToList();
            var newTrainers = await context.Employees
                .Where(e => newTrainerIds.Contains(e.Id))
                .ToListAsync();
            trainingOrderToUpdate.Trainers = newTrainers;
         } else {
            trainingOrderToUpdate.Trainers.Clear();
         }

         if (SelectedTrainerGroupString != null) {
            List<int> newTrainerGroupIds = SelectedTrainerGroupString.Split(", ").Select(int.Parse).ToList();
            var newTrainerGroups = await context.TrainerGroups
                .Where(tg => newTrainerGroupIds.Contains(tg.Id))
                .ToListAsync();
            trainingOrderToUpdate.TrainerGroups = newTrainerGroups;
         } else {
            trainingOrderToUpdate.TrainerGroups.Clear();
         }

         try {
            await context.SaveChangesAsync();
         } catch (DbUpdateConcurrencyException) {
            if (!context.TrainingOrders.Any(e => e.Id == TrainingOrder.Id)) {
               return NotFound();
            } else {
               throw;
            }
         }
         return RedirectToPage("./Index");
      }

      private async Task initJson() {
         Employees = await context.Employees
            .Include(e => e.TrainingOrdersAsTrainee)
            .Include(e => e.TrainingOrdersAsTrainer)
            .Include(e => e.Groups)
            .ToListAsync();

         TrainerGroups = await context.TrainerGroups.ToListAsync();
      }
      private async Task<TrainingOrder?> initOrder(int? id) {
         var trainingorder = await context.TrainingOrders
             .Include(t => t.Trainee)
             .Include(t => t.Location)
             .Include(t => t.Trainers)
             .Include(t => t.TrainerGroups)
             .FirstOrDefaultAsync(m => m.Id == id);

         if (trainingorder != null) {
            return trainingorder;
         } else {
            return null;
         }
      }
   }
}