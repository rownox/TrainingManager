namespace WCSTrainer.Services {
   public interface IImageUploadService {
      Task<ImageUpload?> UploadImageAsync(IFormFile file, string uploadFolder);
      void DeleteImage(string filePath);
   }
}
