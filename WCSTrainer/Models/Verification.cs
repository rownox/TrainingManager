using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Models {
    [Keyless]
    public class Verification {
        public int TrainingOrderID { get; set; }
        public string Completed {  get; set; }
        public int VerifierID { get; set; }
        public DateOnly VerificationDate { get; set; }
        public string Notes { get; set; }
    }
}
