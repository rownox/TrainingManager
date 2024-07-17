using AngleSharp.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.TrainingOrders {
    public class CreateModel : PageModel {
        private readonly WCSTrainerContext _context;
        private readonly DataUtils _dataUtils;

        public CreateModel(WCSTrainerContext context, DataUtils dataUtils) {
            _context = context;
            _dataUtils = dataUtils;
        }

        [BindProperty]
        public TrainingOrder TrainingOrder { get; set; } = new TrainingOrder();
        public DateOnly Day { get; } = DateOnly.FromDateTime(DateTime.Now);
        
        [BindProperty]
        public IList<Employee> Employees { get; set; }
        public IList<TrainerGroup> TrainerGroups { get; set; }
        public SelectList Locations { get; set; }

        public async Task<IActionResult> OnGetAsync() {
            Employees = await _context.Employees.ToListAsync();
            TrainerGroups = await _context.TrainerGroups.ToListAsync();

            ViewData["EmployeesJson"] = System.Text.Json.JsonSerializer.Serialize(Employees ?? new List<Employee>());
            ViewData["TrainerGroupsJson"] = System.Text.Json.JsonSerializer.Serialize(TrainerGroups ?? new List<TrainerGroup>());

            Locations = new SelectList(await _context.Locations.ToListAsync(), "Id", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {

            if (!ModelState.IsValid) {
                await OnGetAsync();
                return Page();
            }

            _context.TrainingOrders.Add(TrainingOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


    }
}
