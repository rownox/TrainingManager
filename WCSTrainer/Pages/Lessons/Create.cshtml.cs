using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;
using WCSTrainer.Services;

namespace WCSTrainer.Pages.Lessons {
   public class CreateModel(WCSTrainerContext context, IImageUploadService imageUploadService) : PageModel {
      [BindProperty]
      public Lesson Lesson { get; set; } = new Lesson();
      [BindProperty]
      public List<IFormFile> ImageUploads { get; set; } = new List<IFormFile>();
      [BindProperty]
      public List<string> ImageCaptions { get; set; } = new List<string>();
      public SelectList CategorySelectList { get; set; }

      public List<string> VideoPaths { get; set; }

      public async Task<IActionResult> OnGetAsync() {
         CategorySelectList = new SelectList(await context.LessonCategories.ToListAsync(), "Id", "Name");
         VideoPaths = GetVideoPaths();
         return Page();
      }

      public async Task<IActionResult> OnPostAsync() {
         if (!ModelState.IsValid) {
            CategorySelectList = new SelectList(await context.LessonCategories.ToListAsync(), "Id", "Name");
            return Page();
         }
         context.Lessons.Add(Lesson);
         await context.SaveChangesAsync();

         for (int i = 0; i < Math.Max(ImageUploads.Count, ImageCaptions.Count); i++) {
            var imageFile = i < ImageUploads.Count ? ImageUploads[i] : null;
            var caption = i < ImageCaptions.Count ? ImageCaptions[i] : null;

            var description = new Description() {
               LessonId = Lesson.Id,
               DisplayOrder = i,
               TextContent = caption
            };
            if (imageFile != null && imageFile.Length > 0) {
               var uploadResult = await imageUploadService.UploadImageAsync(imageFile, "uploads/lessons");
               if (uploadResult != null) {
                  description.FileUploadId = uploadResult.Id;
                  description.FileUpload = uploadResult;
               }
            }
            context.Descriptions.Add(description);
         }
         await context.SaveChangesAsync();
         return RedirectToPage("./Index");
      }

      public List<string> GetVideoPaths() {
         var videoFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Shared", "Videos");
         if (Directory.Exists(videoFolder)) {
            return Directory.GetFiles(videoFolder, "*.*", SearchOption.AllDirectories)
                .Where(file => file.EndsWith(".mp4", StringComparison.OrdinalIgnoreCase) ||
                               file.EndsWith(".webm", StringComparison.OrdinalIgnoreCase) ||
                               file.EndsWith(".ogg", StringComparison.OrdinalIgnoreCase))
                .Select(file => $"/Shared/Videos/{Path.GetRelativePath(videoFolder, file).Replace("\\", "/")}")
                .ToList();
         }
         return new List<string>();
      }
   }
}