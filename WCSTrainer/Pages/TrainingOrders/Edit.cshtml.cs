﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Models;
using WebApplication2.Models;

namespace WCSTrainer.Pages.TrainingOrders {
    public class EditModel : PageModel {

        private readonly WCSTrainer.Data.WCSTrainerContext _context;

        public EditModel(WCSTrainer.Data.WCSTrainerContext context) {
            _context = context;
        }

        [BindProperty]
        public TrainingOrder TrainingOrder { get; set; } = default!;
        [BindProperty]
        public IList<Employee> Employees { get; set; }

        public string[] trainersList;

        public async Task<IActionResult> OnGetAsync(int? id) {
            Employees = await _context.Employee.ToListAsync();

            if (id == null) {
                return NotFound();
            }

            var trainingorder = await _context.TrainingOrder.FirstOrDefaultAsync(m => m.Id == id);
            if (trainingorder == null) {
                return NotFound();
            }
            TrainingOrder = trainingorder;

            trainersList = TrainingOrder.trainers.Split(',');
            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            _context.Attach(TrainingOrder).State = EntityState.Modified;

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
            return _context.TrainingOrder.Any(e => e.Id == id);
        }
    }
}
