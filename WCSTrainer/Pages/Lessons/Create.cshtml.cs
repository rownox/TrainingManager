using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using WCSTrainer.Data;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Lessons {
   public class CreateModel : PageModel {
      private readonly WCSTrainerContext _context;
      private readonly IWebHostEnvironment _webHostEnvironment;

      [BindProperty]
      public Lesson Lesson { get; set; } = new Lesson();
      [BindProperty]
      public Description Description { get; set; }
      public SelectList? CategorySelectList { get; set; }

      public CreateModel(WCSTrainerContext context, IWebHostEnvironment webHostEnvironment) {
         _context = context;
         _webHostEnvironment = webHostEnvironment;
      }

      public async Task<IActionResult> OnGetAsync() {
         CategorySelectList = new SelectList(await _context.LessonCategories.ToListAsync(), "Id", "Name");
         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            CategorySelectList = new SelectList(await _context.LessonCategories.ToListAsync(), "Id", "Name");
            return Page();
         }

         // Save the lesson to the database
         _context.Lessons.Add(Lesson);
         await _context.SaveChangesAsync();

         // Handle the description upload based on the selected type
         if (!string.IsNullOrEmpty(Description.Content)) // Text description
         {
            Description.LessonId = Lesson.Id;
            _context.Descriptions.Add(Description);
         } else if (Description.ImageFile != null) // Image description
           {
            // Save image to server
            var fileName = Path.Combine("uploads", Guid.NewGuid().ToString() + Path.GetExtension(Description.ImageFile.FileName));
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create)) {
               await Description.ImageFile.CopyToAsync(fileStream);
            }

            // Save the file path to the description
            Description.FilePath = fileName;
            Description.LessonId = Lesson.Id;
            _context.Descriptions.Add(Description);
         }

         await _context.SaveChangesAsync();
         return RedirectToPage("./Index");
      }

   }
}