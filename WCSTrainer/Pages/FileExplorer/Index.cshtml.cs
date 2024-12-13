using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WCSTrainer.Pages.FileManager {
   [Authorize(Roles = "owner, admin")]
   public class IndexModel(IWebHostEnvironment webHostEnvironment) : PageModel {

      public List<string> VideoFiles { get; set; } = new List<string>();

      public void OnGet() {
         string videoFolderPath = Path.Combine(webHostEnvironment.WebRootPath, "Shared", "Videos");

         if (Directory.Exists(videoFolderPath)) {
            var files = Directory.GetFiles(videoFolderPath);
            foreach (var file in files) {
               var relativePath = "/Shared/Videos/" + Path.GetFileName(file);
               VideoFiles.Add(relativePath);
            }
         }
      }
   }
}
