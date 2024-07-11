namespace WCSTrainer.Models {
    public class EmployeeTrainerGroup {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int TrainerGroupId { get; set; }
        public TrainerGroup TrainerGroup { get; set; }
    }

}
