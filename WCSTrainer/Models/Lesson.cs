public class Lesson {
   public int Id { get; set; }
   public string Name { get; set; } = string.Empty;
   public ICollection<TrainingOrder> TrainingOrders { get; set; } = new List<TrainingOrder>();
   public int LessonCategoryId { get; set; }
   public LessonCategory? LessonCategory { get; set; }
   public ICollection<Description> Descriptions { get; set; } = new List<Description>();
}