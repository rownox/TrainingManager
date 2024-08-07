﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Skills {
   public class CreateModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public CreateModel(WCSTrainer.Data.WCSTrainerContext context) {
         _context = context;
      }

      public IActionResult OnGet() {
         return Page();
      }

      [BindProperty]
      public Skill Skill { get; set; } = default!;

      public string TrainingOrdersString { get; set; }

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            return Page();
         }

         using var transaction = await _context.Database.BeginTransactionAsync();

         if (TrainingOrdersString != null) {
            var trainingOrderIds = TrainingOrdersString.Split(", ").Select(int.Parse).ToList();
            var orders = await _context.TrainingOrders
                .Where(e => trainingOrderIds.Contains(e.Id))
                .ToListAsync();
            foreach (var i in orders) {
               Skill.TrainingOrders.Add(i);
            }
         }

         _context.Skills.Add(Skill);
         await _context.SaveChangesAsync();
         await transaction.CommitAsync();

         return RedirectToPage("./Index");
      }
   }
}
