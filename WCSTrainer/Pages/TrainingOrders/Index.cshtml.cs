﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.TrainingOrders {
   [Authorize(Roles = "admin, trainer, trainee")]

   public class IndexModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public IndexModel(WCSTrainer.Data.WCSTrainerContext context) {
         _context = context;
      }

      public IList<TrainingOrder> TrainingOrder { get; set; } = default!;
      public IList<Employee> Employees { get; set; }
      public int listCount = 0;
      [BindProperty]
      public int maxCount { get; set; } = 10;

      public async Task OnGetAsync() {
         Employees = await _context.Employees.ToListAsync();
         TrainingOrder = await _context.TrainingOrders.ToListAsync();
      }

      public async Task<IActionResult> OnPostAsync(int? id) {
         if (id != null) {
            var trainingOrder = await _context.TrainingOrders.FindAsync(id);

            if (trainingOrder == null) {
               return NotFound();
            }

            _context.TrainingOrders.Remove(trainingOrder);
            await _context.SaveChangesAsync();
         }

         Employees = await _context.Employees.ToListAsync();
         TrainingOrder = await _context.TrainingOrders.ToListAsync();

         return Page();
      }
   }
}
