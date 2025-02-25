﻿public class TrainingOrder {
   public int Id { get; set; }
   public DateOnly? BeginDate { get; set; }
   public DateOnly? CompletionDate { get; set; }
   public DateOnly? ApprovalDate { get; set; }
   public DateOnly? ScheduleDate { get; set; }
   public DateOnly CreateDate { get; set; }
   public string Status { get; set; } = string.Empty;
   public string? Priority { get; set; }
   public string? ClosingNotes { get; set; }
   public string? Certificate { get; set; }
   public string? ClosedByUserId { get; set; }
   public string? ClosingSignature { get; set; }
   public int? ParentSkillId { get; set; }
   public Skill? ParentSkill { get; set; }
   public int LessonId { get; set; }
   public Lesson? Lesson { get; set; }
   public int TraineeId { get; set; }
   public Employee? Trainee { get; set; }
   public int? LocationId { get; set; }
   public Location? Location { get; set; }
   public int? VerificationId { get; set; }
   public Verification? Verification { get; set; }
   public ICollection<Employee> Trainers { get; set; } = [];
   public ICollection<TrainerGroup> TrainerGroups { get; set; } = [];
   public string? CreatedByUserId { get; set; }
   public bool Archived { get; set; }
}