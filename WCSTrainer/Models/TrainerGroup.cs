public class TrainerGroup {
   public int Id { get; set; }
   public string Name { get; set; }
   public ICollection<Employee> Trainers { get; set; } = new List<Employee>();
   public ICollection<TrainingOrder> TrainingOrders { get; set; } = new List<TrainingOrder>();
}
