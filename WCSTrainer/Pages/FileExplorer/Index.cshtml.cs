using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WCSTrainer.Pages.FileExplorer {
   [Authorize(Roles = "owner, admin")]
   public class IndexModel : PageModel {
      public class FileSystemNode {
         public string Name { get; set; }
         public bool IsFile { get; set; }
         public string Path { get; set; }

         public FileSystemNode(string name, bool isFile, string path) {
            Name = name;
            IsFile = isFile;
            Path = path;
         }
      }

      public string CurrentPath { get; private set; } = "/Shared";
      public List<FileSystemNode> DisplayNodes { get; private set; } = new List<FileSystemNode>();

      public void OnGet(string? path) {
         CurrentPath = path ?? "/Shared";
         DisplayNodes = GetNodesForPath(CurrentPath);
      }

      private List<FileSystemNode> GetNodesForPath(string basePath) {
         var nodes = new List<FileSystemNode>();
         var physicalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", basePath.TrimStart('/'));

         if (Directory.Exists(physicalPath)) {
            foreach (var directory in Directory.GetDirectories(physicalPath)) {
               var name = Path.GetFileName(directory);
               var path = $"{basePath}/{name}";
               nodes.Add(new FileSystemNode(name, false, path));
            }

            foreach (var file in Directory.GetFiles(physicalPath)) {
               var name = Path.GetFileName(file);
               var path = $"{basePath}/{name}";
               nodes.Add(new FileSystemNode(name, true, path));
            }
         }

         return nodes.OrderBy(n => n.IsFile).ThenBy(n => n.Name).ToList();
      }
   }
}
