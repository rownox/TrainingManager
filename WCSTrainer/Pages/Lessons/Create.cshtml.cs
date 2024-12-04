using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;
using WCSTrainer.Services;

namespace WCSTrainer.Pages.Lessons {
   [Authorize(Roles = "owner, admin")]
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

      public List<string> GetFilesInWwwRoot() {
         var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
         var files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);
         return files.Select(f => f.Replace(folderPath, "").Replace("\\", "/")).ToList();
      }
   }
}