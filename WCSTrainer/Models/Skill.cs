public class Skill {
  public int Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public ICollection<TrainingOrder> TrainingOrders { get; set; } = new List<TrainingOrder>();
  public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}