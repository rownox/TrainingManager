namespace WCSTrainer.Models {
    public class TrainerGroup {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Trainer> Trainers { get; set; }
    }
}
