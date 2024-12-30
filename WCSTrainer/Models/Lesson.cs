public class Lesson {
   public int Id { get; set; }
   public string Name { get; set; } = string.Empty;
   public int Duration { get; set; }
   public string Content { get; set; } = string.Empty;

   public ICollection<TrainingOrder> TrainingOrders { get; set; } = new List<TrainingOrder>();
   public int LessonCategoryId { get; set; }
   public LessonCategory? LessonCategory { get; set; }
}