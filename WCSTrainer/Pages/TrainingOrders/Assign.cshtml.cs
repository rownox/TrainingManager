using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.TrainingOrders {
    public class AssignModel : PageModel {

        private readonly WCSTrainerContext _context;
        public AssignModel(WCSTrainerContext context) {
            _context = context;
        }

        [BindProperty]
        public IList<Skill> Skills { get; set; }
        public Skill selectedSkill { get; set; }
        public SelectList selectSkills { get; set; }
        public int SelectedSkillId { get; set; } = 1;

        [BindProperty]
        public IList<Employee> Employees { get; set; }
        public Employee selectedEmployee { get; set; }
        public SelectList selectEmployees { get; set; }
        public int SelectedEmployeeId { get; set; } = 1;


        public async Task<IActionResult> OnGetAsync() {
            Skills = await _context.Skills.ToListAsync();
            Employees = await _context.Employees.ToListAsync();
            selectSkills = new SelectList(Skills, "Id", "Name");
            selectEmployees = new SelectList(Employees, "Id", "FirstName");
            selectedSkill = await _context.Skills.FirstOrDefaultAsync(m => m.Id == SelectedSkillId);
            selectedEmployee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == SelectedEmployeeId);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            selectedEmployee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == SelectedEmployeeId);
            selectedSkill = await _context.Skills.FirstOrDefaultAsync(m => m.Id == SelectedSkillId);

            return Page();
        }
    }
}
