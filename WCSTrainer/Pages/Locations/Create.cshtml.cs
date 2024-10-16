﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WCSTrainer.Pages.Locations {
   [Authorize(Roles = "owner, admin")]
   public class CreateModel : PageModel {
      private readonly WCSTrainer.Data.WCSTrainerContext _context;

      public CreateModel(WCSTrainer.Data.WCSTrainerContext context) {
         _context = context;
      }

      public IActionResult OnGet() {
         return Page();
      }

      [BindProperty]
      public Location Location { get; set; } = default!;

      // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            return Page();
         }

         _context.Locations.Add(Location);
         await _context.SaveChangesAsync();

         return RedirectToPage("./Index");
      }
   }
}
