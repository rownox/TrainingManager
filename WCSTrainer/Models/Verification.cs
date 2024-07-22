public class Verification {
    public int Id { get; set; }
    public DateOnly? VerifyDate { get; set; }
    public string VerifyNotes { get; set; } = string.Empty;
    public string Signature { get; set; } = string.Empty;
    public string? VerifierId { get; set; }
    public UserAccount? Verifier { get; set; }
    public int TrainingOrderId { get; set; }
    public TrainingOrder? TrainingOrder { get; set; }
}