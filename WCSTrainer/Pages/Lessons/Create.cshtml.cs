using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using WCSTrainer.Data;
using WCSTrainer.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Lessons {
   public class CreateModel : PageModel {
      private readonly WCSTrainerContext _context;
      private readonly IImageUploadService _imageUploadService;

      [BindProperty]
      public Lesson Lesson { get; set; } = new Lesson();

      [BindProperty]
      public Description Description { get; set; } = new Description();

      [BindProperty]
      public List<IFormFile> ImageUploads { get; set; } = new List<IFormFile>();

      [BindProperty]
      public List<string> ImageCaptions { get; set; } = new List<string>();

      public SelectList CategorySelectList { get; set; }

      public CreateModel(WCSTrainerContext context, IImageUploadService imageUploadService) {
         _context = context;
         _imageUploadService = imageUploadService;
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

         // Save lesson
         _context.Lessons.Add(Lesson);
         await _context.SaveChangesAsync();

         // Save description
         Description.LessonId = Lesson.Id;
         _context.Descriptions.Add(Description);
         await _context.SaveChangesAsync();

         // Handle image uploads
         for (int i = 0; i < ImageUploads.Count; i++) {
            var imageFile = ImageUploads[i];
            if (imageFile != null && imageFile.Length > 0) {
               var uploadResult = await _imageUploadService.UploadImageAsync(imageFile, "uploads/lessons");
               if (uploadResult != null) {
                  var newDescription = new Description {
                     LessonId = Lesson.Id,
                     ImageUploadId = uploadResult.Id,
                     TextContent = i < ImageCaptions.Count ? ImageCaptions[i] : null,
                  };

                  _context.Descriptions.Add(newDescription);
               }
            }
         }

         await _context.SaveChangesAsync();

         return RedirectToPage("./Index");
      }
   }
}