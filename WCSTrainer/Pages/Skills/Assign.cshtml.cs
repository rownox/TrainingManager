using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using System.Text.Json.Serialization;
using System.Text.Json;
using WCSTrainer.Data;
using Microsoft.AspNetCore.Identity;
using System.Net.NetworkInformation;
using System.Security.Claims;

namespace WCSTrainer.Pages.Skills {
   public class AssignModel(WCSTrainerContext context) : PageModel {

      [BindProperty]
      public Skill Skill { get; set; } = default!;
      [BindProperty]
      public int SelectedTraineeId { get; set; }

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var skill = await context.Skills
             .Include(s => s.Employees)
             .Include(s => s.Lessons)
             .FirstOrDefaultAsync(m => m.Id == id);

         if (skill == null) {
            return NotFound();
         }

         Skill = skill;
         await LoadRelatedData();

         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            await LoadRelatedData();
            return Page();
         }

         var trainee = await context.Employees
             .Include(t => t.TrainingOrdersAsTrainee)
             .Include(t => t.Skills)
             .FirstOrDefaultAsync(e => e.Id == SelectedTraineeId);

         if (trainee == null) {
            ModelState.AddModelError("", "Selected trainee not found.");
            await LoadRelatedData();
            return Page();
         }

         var skill = await context.Skills
             .Include(s => s.Lessons)
             .Include(s => s.Employees)
             .FirstOrDefaultAsync(s => s.Id == Skill.Id);

         if (skill == null) {
            ModelState.AddModelError("", "Selected skill not found.");
            await LoadRelatedData();
            return Page();
         }

         if (skill.Employees.Contains(trainee)) {
            ModelState.AddModelError("", "The skill was already assigned to this employee.");
            await LoadRelatedData();
            return Page();
         }

         using var transaction = await context.Database.BeginTransactionAsync();

         try {
            if (!trainee.Skills.Any(s => s.Id == skill.Id)) {
               trainee.Skills.Add(skill);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) {
               return Unauthorized();
            }

            foreach (var lesson in skill.Lessons) {
               var newOrder = new TrainingOrder {
                  CreateDate = DateOnly.FromDateTime(DateTime.Now),
                  Status = "Awaiting Approval",
                  LessonId = lesson.Id,
                  TraineeId = trainee.Id,
                  ParentSkillId = Skill.Id,
                  CreatedByUserId = userId
               };

               context.TrainingOrders.Add(newOrder);
               trainee.TrainingOrdersAsTrainee.Add(newOrder);
            }

            await context.SaveChangesAsync();
            await transaction.CommitAsync();

            return RedirectToPage("./Index");
         } catch (DbUpdateConcurrencyException) {
            await transaction.RollbackAsync();
            if (!await context.Employees.AnyAsync(e => e.Id == trainee.Id)) {
               return NotFound();
            } else {
               ModelState.AddModelError("", "Concurrency error occurred. Please try again.");
               await LoadRelatedData();
               return Page();
            }
         } catch (Exception ex) {
            await transaction.RollbackAsync();
            ModelState.AddModelError("", $"An error occurred: {ex.Message}");
            await LoadRelatedData();
            return Page();
         }
      }

      private async Task LoadRelatedData() {
         var employees = await context.Employees
             .Select(e => new { e.Id, e.FirstName, e.LastName, e.Status })
             .ToListAsync();

         var trainerGroups = await context.TrainerGroups
             .Select(tg => new { tg.Id, tg.Name })
             .ToListAsync();

         ViewData["EmployeesJson"] = JsonSerializer.Serialize(employees);
         ViewData["TrainerGroupsJson"] = JsonSerializer.Serialize(trainerGroups);
      }

      private JsonSerializerOptions GetJsonSerializerOptions() {
         return new JsonSerializerOptions {
            ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true
         };
      }
   }
}
