public class Description {
   public int Id { get; set; }
   public int LessonId { get; set; }
   public Lesson Lesson { get; set; }
   public string? TextContent { get; set; }
   public int? ImageUploadId { get; set; }
   public ImageUpload? ImageUpload { get; set; }
   public DescriptionType DescriptionType { get; set; }
}

public enum DescriptionType {
   TextOnly,
   ImageOnly,
   TextWithImage
}



