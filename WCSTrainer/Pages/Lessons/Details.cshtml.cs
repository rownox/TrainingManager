﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.Lessons
{
    public class DetailsModel : PageModel
    {
        private readonly WCSTrainer.Data.WCSTrainerContext _context;

        public DetailsModel(WCSTrainer.Data.WCSTrainerContext context)
        {
            _context = context;
        }

        public Lesson Lesson { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons.FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }
            else
            {
                Lesson = lesson;
            }
            return Page();
        }
    }
}
