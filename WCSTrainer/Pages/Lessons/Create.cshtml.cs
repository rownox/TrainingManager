using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using WCSTrainer.Data;
using WCSTrainer.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.Lessons {
   public class CreateModel(WCSTrainerContext context, IImageUploadService imageUploadService) : PageModel {
      [BindProperty]
      public Lesson Lesson { get; set; } = new Lesson();

      [BindProperty]
      public List<IFormFile> ImageUploads { get; set; } = new List<IFormFile>();

      [BindProperty]
      public List<string> ImageCaptions { get; set; } = new List<string>();

      public SelectList CategorySelectList { get; set; }

      public async Task<IActionResult> OnGetAsync() {
         CategorySelectList = new SelectList(await context.LessonCategories.ToListAsync(), "Id", "Name");
         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            CategorySelectList = new SelectList(await context.LessonCategories.ToListAsync(), "Id", "Name");
            return Page();
         }

         context.Lessons.Add(Lesson);
         await context.SaveChangesAsync();

         for (int i = 0; i < ImageUploads.Count; i++) {
            var imageFile = ImageUploads[i];
            if (imageFile != null && imageFile.Length > 0) {
               var uploadResult = await imageUploadService.UploadImageAsync(imageFile, "uploads/lessons");
               if (uploadResult != null) {
                  var description = new Description() {
                     LessonId = Lesson.Id,
                     ImageUploadId = uploadResult.Id,
                     ImageUpload = uploadResult,
                     DisplayOrder = i,
                     TextContent = i < ImageCaptions.Count ? ImageCaptions[i] : null
                  };

                  context.Descriptions.Add(description);
                  await context.SaveChangesAsync();
               }
            }
         }

         await context.SaveChangesAsync();

         return RedirectToPage("./Index");
      }
   }
}