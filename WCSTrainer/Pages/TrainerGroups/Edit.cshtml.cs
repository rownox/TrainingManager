using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.TrainerGroups
{
    public class EditModel : PageModel
    {
        private readonly WCSTrainer.Data.WCSTrainerContext _context;

        public EditModel(WCSTrainer.Data.WCSTrainerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TrainerGroup TrainerGroup { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainergroup =  await _context.TrainerGroups.FirstOrDefaultAsync(m => m.Id == id);
            if (trainergroup == null)
            {
                return NotFound();
            }
            TrainerGroup = trainergroup;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TrainerGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainerGroupExists(TrainerGroup.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TrainerGroupExists(int id)
        {
            return _context.TrainerGroups.Any(e => e.Id == id);
        }
    }
}
