public class Skill {
   public int Id { get; set; }
   public string Name { get; set; } = string.Empty;
   public string Description { get; set; } = string.Empty;
   public string? Checklist { get; set; }
   public ICollection<Lesson> Lessons { get; set; } = [];
   public ICollection<Employee> Employees { get; set; } = [];
   public ICollection<TrainingOrder> TrainingOrders { get; set; } = [];
   public int SkillCategoryId { get; set; }
   public SkillCategory? SkillCategory { get; set; }
}