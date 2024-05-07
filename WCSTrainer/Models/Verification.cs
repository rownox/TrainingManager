namespace WCSTrainer.Models {
    public class Verification {
        public int TrainingID { get; set; }
        public string Completed {  get; set; }
        public int VerifierID { get; set; }
        public DateOnly VerificationDate { get; set; }
        public string Notes { get; set; }
    }
}
