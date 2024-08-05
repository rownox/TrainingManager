public class Location {
  public int Id { get; set; }
  public string Name { get; set; }
  public ICollection<TrainingOrder> TrainingOrders { get; set; } = new List<TrainingOrder>();
}