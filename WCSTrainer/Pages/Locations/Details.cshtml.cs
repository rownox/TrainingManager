﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Locations {
   [Authorize(Roles = "owner, admin, user")]
   public class DetailsModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public DetailsModel(WCSTrainer.Data.WCSTrainerContext context) {
         _context = context;
      }
      [BindProperty]
      public Location Location { get; set; } = default!;

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var location = await _context.Locations
            .Include(l => l.TrainingOrders)
            .ThenInclude(t => t.Lesson)
            .FirstOrDefaultAsync(m => m.Id == id);
         if (location == null) {
            return NotFound();
         } else {
            Location = location;
         }
         return Page();
      }
   }
}
