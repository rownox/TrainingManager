namespace WCSTrainer.Services {
   public interface IImageUploadService {
      Task<ImageUpload?> UploadImageAsync(IFormFile file, string uploadFolder);
      void DeleteImage(string filePath);
   }

   public class ImageUploadService : IImageUploadService {
      private readonly IWebHostEnvironment _environment;
      private readonly ILogger<ImageUploadService> _logger;

      public ImageUploadService(IWebHostEnvironment environment, ILogger<ImageUploadService> logger) {
         _environment = environment;
         _logger = logger;
      }

      public async Task<ImageUpload?> UploadImageAsync(IFormFile file, string uploadFolder) {
         if (file == null || file.Length == 0)
            return null;

         try {
            // Validate file
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var maxFileSize = 5 * 1024 * 1024; // 5MB

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(extension))
               throw new ArgumentException("Invalid file type");

            if (file.Length > maxFileSize)
               throw new ArgumentException("File size exceeds maximum limit");

            // Create upload directory if it doesn't exist
            var uploadPath = Path.Combine(_environment.WebRootPath, uploadFolder);
            Directory.CreateDirectory(uploadPath);

            // Generate unique filename
            var uniqueFileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(uploadPath, uniqueFileName);

            // Save file
            using (var stream = new FileStream(filePath, FileMode.Create)) {
               await file.CopyToAsync(stream);
            }

            // Create ImageUpload record
            return new ImageUpload {
               FileName = file.FileName,
               FilePath = Path.Combine(uploadFolder, uniqueFileName),
               FileSize = file.Length,
               FileType = extension
            };
         } catch (Exception ex) {
            _logger.LogError(ex, "Error uploading image");
            return null;
         }
      }

      public void DeleteImage(string filePath) {
         var fullPath = Path.Combine(_environment.WebRootPath, filePath);
         if (File.Exists(fullPath)) {
            File.Delete(fullPath);
         }
      }
   }
}
