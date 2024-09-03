public class Employee {
   public int Id { get; set; }
   public string FirstName { get; set; } = string.Empty;
   public string LastName { get; set; } = string.Empty;
   public string Status { get; set; } = string.Empty;
   public string? UserAccountId { get; set; }
   public UserAccount? UserAccount { get; set; }
   public ICollection<Skill> Skills { get; set; } = new List<Skill>();
   public ICollection<TrainingOrder> TrainingOrdersAsTrainee { get; set; } = new List<TrainingOrder>();
   public ICollection<TrainingOrder> TrainingOrdersAsTrainer { get; set; } = new List<TrainingOrder>();
}