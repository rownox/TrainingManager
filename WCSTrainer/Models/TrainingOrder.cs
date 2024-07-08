namespace WCSTrainer.Models {
    public class TrainingOrder {
        public int Id { get; set; }
        public string Skill { get; set; }
        public string Trainers { get; set; }
        public string Trainee { get; set; }
        public DateOnly BeginDate { get; set; }
        public DateOnly EndDate { get; set; }
        public DateOnly CreateDate { get; set; }
        public string Location { get; set; }
        public string Medium { get; set; }
        public string Status { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
    }
}
