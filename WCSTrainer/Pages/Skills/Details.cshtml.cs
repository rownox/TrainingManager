﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Skills {
   [Authorize(Roles = "owner, admin, user")]
   public class DetailsModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public DetailsModel(WCSTrainer.Data.WCSTrainerContext context) {
         _context = context;
      }

      public Skill Skill { get; set; } = default!;

      public async Task<IActionResult> OnGetAsync(int? id) {
         if (id == null) {
            return NotFound();
         }

         var skill = await _context.Skills
            .Include(s => s.Lessons)
            .Include(s => s.Employees)
               .ThenInclude(e => e.TrainingOrdersAsTrainee)
            .FirstOrDefaultAsync(m => m.Id == id);
         if (skill == null) {
            return NotFound();
         } else {
            Skill = skill;
         }
         return Page();
      }
   }
}
