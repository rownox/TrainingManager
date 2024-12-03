namespace WCSTrainer.Services {
   public interface IImageUploadService {
      Task<FileUpload?> UploadImageAsync(IFormFile file, string uploadFolder);
      void DeleteImage(string filePath);
   }
}
