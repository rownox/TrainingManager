namespace WCSTrainer.Models {
    public class Employee {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }
        public List<string> Skills { get; set; }

        public ICollection<TrainingOrder> TrainingOrders { get; set; }
        public UserAccount User { get; set; } 
        public int UserId { get; set; }
        public ICollection<TrainerGroup> TrainerGroups { get; set; }
    }
}
