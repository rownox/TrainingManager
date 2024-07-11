namespace WCSTrainer.Models {
    public class Verification {
        public int Id { get; set; }
        public DateOnly VerifyDate { get; set; }
        public string CompleteNotes { get; set; }
        public string VerifyNotes { get; set; }

        public Employee Verifier { get; set; }
        public TrainingOrder TrainingOrder { get; set; }
        public int TrainingOrderId { get; set; }
    }
}
