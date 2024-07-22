public class TrainingOrder {
    public int Id { get; set; }
    public DateOnly BeginDate { get; set; }
    public DateOnly EndDate { get; set; }
    public DateOnly CreateDate { get; set; }
    public string Medium { get; set; }
    public string Status { get; set; }
    public int Duration { get; set; }
    public string Priority { get; set; }
    public string Description { get; set; }
    public string ClosingNotes { get; set; } = string.Empty;
    public int TraineeId { get; set; }
    public Employee? Trainee { get; set; }
    public int LocationId { get; set; }
    public Location? Location { get; set; }
    public int? VerificationId { get; set; }
    public Verification? Verification { get; set; }
    public ICollection<Employee> Trainers { get; set; } = new List<Employee>();
    public ICollection<TrainerGroup> TrainerGroups { get; set; } = new List<TrainerGroup>();
    public ICollection<Skill> Skills { get; set; } = new List<Skill>();
}