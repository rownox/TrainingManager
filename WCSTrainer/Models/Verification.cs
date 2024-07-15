public class Verification {
    public int Id { get; set; }
    public DateOnly? VerifyDate { get; set; }
    public string? CompleteNotes { get; set; }
    public string? VerifyNotes { get; set; }

    public int? VerifierId { get; set; }
    public int TrainingOrderId { get; set; }
}