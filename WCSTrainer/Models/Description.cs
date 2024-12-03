public class Description {
   public int Id { get; set; }
   public int LessonId { get; set; }
   public Lesson? Lesson { get; set; }
   public string? TextContent { get; set; }
   public int? FileUploadId { get; set; }
   public FileUpload? FileUpload { get; set; }
   public int DisplayOrder { get; set; }
}