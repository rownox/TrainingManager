public class Employee {
   public int Id { get; set; }
   public string FirstName { get; set; } = string.Empty;
   public string LastName { get; set; } = string.Empty;
   public string UserAccountId { get; set; } = string.Empty;
   public string JobTitle { get; set; } = string.Empty;
   public int Shift { get; set; }
   public int EmployeeID { get; set; }
   public bool Active { get; set; }
   public UserAccount? UserAccount { get; set; }
   public ICollection<Skill> Skills { get; set; } = [];
   public ICollection<TrainerGroup> Groups { get; set; } = [];
   public ICollection<TrainingOrder> TrainingOrdersAsTrainee { get; set; } = [];
   public ICollection<TrainingOrder> TrainingOrdersAsTrainer { get; set; } = [];
   public ICollection<LessonCategory> TrainerDepartments { get; set; } = [];
}