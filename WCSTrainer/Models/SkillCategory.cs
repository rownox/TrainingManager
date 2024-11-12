public class SkillCategory {
   public int Id { get; set; }
   public string Name { get; set; } = string.Empty;
   public List<Skill> Skills { get; set; } = new List<Skill>();
}