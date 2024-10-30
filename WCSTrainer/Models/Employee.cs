public class Employee {
   public int Id { get; set; }
   public string FirstName { get; set; } = string.Empty;
   public string LastName { get; set; } = string.Empty;
   public string Status { get; set; } = string.Empty;
   public string UserAccountId { get; set; } = string.Empty;
   public UserAccount? UserAccount { get; set; }
   public ICollection<Skill> Skills { get; set; } = [];
   public ICollection<TrainingOrder> TrainingOrdersAsTrainee { get; set; } = [];
   public ICollection<TrainingOrder> TrainingOrdersAsTrainer { get; set; } = [];
   public ICollection<TrainerGroup> Groups { get; set; } = [];
}