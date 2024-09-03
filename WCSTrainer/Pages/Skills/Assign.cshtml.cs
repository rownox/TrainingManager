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
   public class AssignModel : PageModel {

      private readonly WCSTrainerContext _context;

      public AssignModel(WCSTrainerContext context) {
         _context = context;
      }

      [BindProperty]
      public Skill Skill { get; set; } = default!;
      [BindProperty]
      public IList<Employee> Employees { get; set; }
      [BindProperty]
      public IList<TrainerGroup> TrainerGroups { get; set; }

      //[BindProperty]
      //public string? SelectedTrainerString { get; set; }
      //public List<int> SelectedTrainerIds { get; set; } = new List<int>();
      //[BindProperty]
      //public string? SelectedTrainerGroupString { get; set; }
      //public List<int> SelectedTrainerGroupIds { get; set; } = new List<int>();

      [BindProperty]
      public int SelectedTraineeId { get; set; }

      public async Task<IActionResult> OnGetAsync(int? id) {
         Employees = await _context.Employees.ToListAsync();
         ViewData["EmployeesJson"] = JsonSerializer
              .Serialize(Employees ?? new List<Employee>());
         TrainerGroups = await _context.TrainerGroups.ToListAsync();
         ViewData["TrainerGroupsJson"] = JsonSerializer
              .Serialize(TrainerGroups ?? new List<TrainerGroup>());

         if (id == null) {
            return NotFound();
         }

         var tempSkill = await _context.Skills
             .Include(s => s.Employees)
             .Include(s => s.Lessons)
             .FirstOrDefaultAsync(m => m.Id == id);

         if (tempSkill == null) {
            return NotFound();
         } else {
            Skill = tempSkill;
         }

         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            await LoadRelatedData();
            return Page();
         }

         var trainee = await _context.Employees
             .Include(t => t.TrainingOrdersAsTrainee)
             .Include(t => t.Skills)
             .FirstOrDefaultAsync(e => e.Id == SelectedTraineeId);

         if (trainee == null) {
            ModelState.AddModelError("", "Selected trainee not found.");
            await LoadRelatedData();
            return Page();
         }

         var skill = await _context.Skills
             .Include(s => s.Lessons)
             .FirstOrDefaultAsync(s => s.Id == Skill.Id);

         if (skill == null) {
            ModelState.AddModelError("", "Selected skill not found.");
            await LoadRelatedData();
            return Page();
         }

         using var transaction = await _context.Database.BeginTransactionAsync();

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

               _context.TrainingOrders.Add(newOrder);
               trainee.TrainingOrdersAsTrainee.Add(newOrder);
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return RedirectToPage("./Index");
         } catch (DbUpdateConcurrencyException) {
            await transaction.RollbackAsync();
            if (!await _context.Employees.AnyAsync(e => e.Id == trainee.Id)) {
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
         Employees = await _context.Employees.ToListAsync();
         TrainerGroups = await _context.TrainerGroups.ToListAsync();
         ViewData["EmployeesJson"] = JsonSerializer.Serialize(Employees);
         ViewData["TrainerGroupsJson"] = JsonSerializer.Serialize(TrainerGroups);
      }

      //private async Task<List<TrainerGroup>> GetSelectedTrainerGroups() {
      //   if (string.IsNullOrEmpty(SelectedTrainerGroupString))
      //      return new List<TrainerGroup>();

      //   var ids = SelectedTrainerGroupString.Split(',').Select(s => int.TryParse(s.Trim(), out int id) ? id : -1).Where(id => id != -1).ToList();
      //   return await _context.TrainerGroups.Where(tg => ids.Contains(tg.Id)).ToListAsync();
      //}

      //private async Task<List<Employee>> GetSelectedTrainers() {
      //   if (string.IsNullOrEmpty(SelectedTrainerString))
      //      return new List<Employee>();

      //   var ids = SelectedTrainerString.Split(',').Select(s => int.TryParse(s.Trim(), out int id) ? id : -1).Where(id => id != -1).ToList();
      //   return await _context.Employees.Where(e => ids.Contains(e.Id)).ToListAsync();
      //}

      private JsonSerializerOptions GetJsonSerializerOptions() {
         return new JsonSerializerOptions {
            ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true
         };
      }

   }
}
