public class Verification {
    public int Id { get; set; }
    public DateOnly? VerifyDate { get; set; }
    public string VerifyNotes { get; set; } = string.Empty;
    public int? VerifierId { get; set; }
    public Employee? Verifier { get; set; }
    public int TrainingOrderId { get; set; }
    public TrainingOrder? TrainingOrder { get; set; }
}