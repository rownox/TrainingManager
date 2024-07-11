using WCSTrainer.Models;

public class TrainingOrder {
    public int Id { get; set; }
    public string Skill { get; set; }
    public DateOnly BeginDate { get; set; }
    public DateOnly EndDate { get; set; }
    public DateOnly CreateDate { get; set; }
    public int LocationId { get; set; }
    public Location LocationObject { get; set; }
    public string Medium { get; set; }
    public string Status { get; set; }
    public int Duration { get; set; }
    public string Priority { get; set; }
    public ICollection<Employee> Trainers { get; set; }
    public Employee Trainee { get; set; }
    public int TraineeId { get; set; }
    public Verification Verification { get; set; }
}