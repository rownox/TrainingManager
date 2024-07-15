using WCSTrainer.Models;

public class TrainingOrder {
    public int Id { get; set; }
    public string Skill { get; set; }
    public DateOnly BeginDate { get; set; }
    public DateOnly EndDate { get; set; }
    public DateOnly CreateDate { get; set; }
    public string Medium { get; set; }
    public string Status { get; set; }
    public int Duration { get; set; }
    public string Priority { get; set; }

    public int TraineeId { get; set; }
    public int LocationId { get; set; }
    public int? VerificationId { get; set; }
    public List<int>? TrainerIds { get; set; }
}