using WCSTrainer.Models;

public class Lesson {
   public int Id { get; set; }
   public string Name { get; set; } = string.Empty;
   public ICollection<TrainingOrder> TrainingOrders { get; set; } = [];
   public int LessonCategoryId { get; set; }
   public LessonCategory? LessonCategory { get; set; }
   public int DescriptionId { get; set; }
   public Description? Description { get; set; }
}