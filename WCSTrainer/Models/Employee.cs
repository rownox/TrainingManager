using WCSTrainer.Models;

public class Employee {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Status { get; set; }
    public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    public ICollection<TrainingOrder> TrainingOrders { get; set; }
    public UserAccount User { get; set; }
    public string UserId { get; set; }
    public ICollection<EmployeeTrainerGroup> EmployeeTrainerGroups { get; set; }
}