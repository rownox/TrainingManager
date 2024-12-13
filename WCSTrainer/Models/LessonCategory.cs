public class LessonCategory {
   public int Id { get; set; }
   public string Name { get; set; } = string.Empty;
   public List<Lesson> Lessons { get; set; } = new List<Lesson>();
   public List<Employee> Trainers { get; set; } = new List<Employee>();
}