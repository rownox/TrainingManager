public class Skill {
   public int Id { get; set; }
   public string Name { get; set; }
   public string Description { get; set; }
   public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
   public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}