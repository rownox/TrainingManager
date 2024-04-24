using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Models;

namespace WCSTrainer.Pages.TrainingOrders
{
    public class CreateModel : PageModel
    {
        private readonly WCSTrainer.Data.WCSTrainerContext _context;

        public List<SelectListItem> Individuals { get; set; }
        public List<SelectListItem> Groups { get; set; }
        public List<SelectListItem> Locations { get; set; }

        public CreateModel(WCSTrainer.Data.WCSTrainerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Individuals = new List<SelectListItem> {
                new SelectListItem { Text = "Aadam Husain" },
                new SelectListItem { Text = "Jay Dunwell" },
                new SelectListItem { Text = "Craig Grambau" },
                new SelectListItem { Text = "Donna Crowl" },
                new SelectListItem { Text = "Kay Selim" }
            };

            Groups = new List<SelectListItem> {
                new SelectListItem { Text = "HR" },
                new SelectListItem { Text = "Sales" },
                new SelectListItem { Text = "Shipping" },
                new SelectListItem { Text = "Tooling" }
            };

            Locations = new List<SelectListItem> {
                new SelectListItem { Text = "Four Slide Machine 1" },
                new SelectListItem { Text = "Four Slide Machine 2" },
                new SelectListItem { Text = "Four Slide Machine 3" },
                new SelectListItem { Text = "Tool Room" },
                new SelectListItem { Text = "The Office" }
            };

            return Page();
        }

        [BindProperty]
        public TrainingOrder TrainingOrder { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TrainingOrder.Add(TrainingOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
