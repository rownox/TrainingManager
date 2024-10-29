public class Lesson {
   public int Id { get; set; }
   public string Name { get; set; } = string.Empty;
   public string Description { get; set; } = string.Empty;
   public ICollection<TrainingOrder> TrainingOrders { get; set; } = [];
}