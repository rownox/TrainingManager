namespace WCSTrainer.Models {
    public class Skill {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
