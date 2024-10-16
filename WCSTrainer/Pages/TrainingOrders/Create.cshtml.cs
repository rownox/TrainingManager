﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.TrainingOrders {
   [Authorize(Roles = "owner, admin, user")]
   public class CreateModel(WCSTrainerContext context) : PageModel {
      [BindProperty]
      public TrainingOrder TrainingOrder { get; set; } = new TrainingOrder();
      [BindProperty]
      public IList<Employee>? Employees { get; set; }
      public SelectList LessonSelectList { get; set; }

      public async Task<IActionResult> OnGetAsync() {
         Employees = await context.Employees.ToListAsync();
         LessonSelectList = new SelectList(await context.Lessons.ToListAsync(), "Id", "Name");
         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {

         if (!ModelState.IsValid) {
            await OnGetAsync();
            return Page();
         }

         context.TrainingOrders.Add(TrainingOrder);
         await context.SaveChangesAsync();

         return RedirectToPage("./Index");
      }
   }
}
