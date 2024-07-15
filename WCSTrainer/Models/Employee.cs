using WCSTrainer.Models;

public class Employee {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Status { get; set; }

    public string? UserId { get; set; }
    public List<int> SkillIds { get; set; }
    public List<int> TrainingOrderIds { get; set; }
}