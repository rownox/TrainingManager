using System.ComponentModel.DataAnnotations.Schema;

public class Description {
   public int Id { get; set; }
   public int LessonId { get; set; }
   public Lesson? Lesson { get; set; }

   public string Content { get; set; } = string.Empty;
   public string? FilePath { get; set; }
   [NotMapped]
   public IFormFile? ImageFile { get; set; }
}
