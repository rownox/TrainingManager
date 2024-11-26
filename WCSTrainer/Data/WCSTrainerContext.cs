using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WCSTrainer.Models;

namespace WCSTrainer.Data {
   public class WCSTrainerContext : IdentityDbContext<UserAccount> {
      public WCSTrainerContext(DbContextOptions<WCSTrainerContext> options)
          : base(options) {
      }

      public DbSet<Employee> Employees { get; set; } = default!;
      public DbSet<Location> Locations { get; set; } = default!;
      public DbSet<Skill> Skills { get; set; } = default!;
      public DbSet<TrainerGroup> TrainerGroups { get; set; } = default!;
      public DbSet<TrainingOrder> TrainingOrders { get; set; } = default!;    
      public DbSet<Verification> Verifications { get; set; } = default!;
      public DbSet<Lesson> Lessons { get; set; } = default!;         
      public DbSet<LessonCategory> LessonCategories { get; set; } = default!; 
      public DbSet<SkillCategory> SkillCategories { get; set; } = default!;      
      public DbSet<Description> Descriptions { get; set; } = default!;
      public DbSet<ImageUpload> ImageUploads { get; set; } = default!;

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
         optionsBuilder.ConfigureWarnings(warnings =>
             warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
         base.OnConfiguring(optionsBuilder);
      }

      protected override void OnModelCreating(ModelBuilder builder) {
         base.OnModelCreating(builder);

         //Employee
         builder.Entity<Employee>()
                .HasOne(u => u.UserAccount)
                .WithOne(e => e.Employee)
                .HasForeignKey<Employee>(e => e.UserAccountId);

         builder.Entity<Employee>()
             .HasMany(e => e.Skills)
             .WithMany(s => s.Employees);

         builder.Entity<Employee>()
             .HasMany(e => e.TrainingOrdersAsTrainee)
             .WithOne(to => to.Trainee)
             .HasForeignKey(to => to.TraineeId)
             .OnDelete(DeleteBehavior.Restrict);

         builder.Entity<Employee>()
             .HasMany(e => e.TrainingOrdersAsTrainer)
             .WithMany(to => to.Trainers);

         // Lesson
         builder.Entity<Lesson>()
             .HasMany(l => l.TrainingOrders)
             .WithOne(to => to.Lesson)
             .HasForeignKey(to => to.LessonId);

         builder.Entity<Lesson>()
            .HasMany(l => l.Descriptions)
            .WithOne(d => d.Lesson)
            .HasForeignKey(d => d.LessonId);

         // Location
         builder.Entity<Location>()
             .HasMany(l => l.TrainingOrders)
             .WithOne(to => to.Location)
             .HasForeignKey(to => to.LocationId)
             .OnDelete(DeleteBehavior.SetNull);

         // Skill
         builder.Entity<Skill>()
             .HasMany(s => s.Lessons)
             .WithMany();

         builder.Entity<Skill>()
          .HasMany(s => s.TrainingOrders)
          .WithOne(to => to.ParentSkill)
          .HasForeignKey(to => to.ParentSkillId)
          .OnDelete(DeleteBehavior.SetNull);

         // TrainerGroup
         builder.Entity<TrainerGroup>()
             .HasMany(tg => tg.Trainers)
             .WithMany(e => e.Groups);

         builder.Entity<TrainerGroup>()
             .HasMany(tg => tg.TrainingOrders)
             .WithMany(to => to.TrainerGroups);

         // TrainingOrder
         builder.Entity<TrainingOrder>()
             .HasOne(to => to.ParentSkill)
             .WithMany()
             .HasForeignKey(to => to.ParentSkillId)
             .OnDelete(DeleteBehavior.SetNull);

         builder.Entity<TrainingOrder>()
             .HasOne(to => to.Verification)
             .WithOne(v => v.TrainingOrder)
             .HasForeignKey<Verification>(v => v.TrainingOrderId);

         // Verification
         builder.Entity<Verification>()
             .HasOne(v => v.Verifier)
             .WithMany()
             .HasForeignKey(v => v.VerifierId);

         //SkillCategory
         builder.Entity<SkillCategory>()
            .HasMany(sc => sc.Skills)
            .WithOne(s => s.SkillCategory);

         //LessonCategory
         builder.Entity<LessonCategory>()
            .HasMany(lc => lc.Lessons)
            .WithOne(l => l.LessonCategory);

         var ownerRole = new IdentityRole("owner") { NormalizedName = "OWNER" };
         var adminRole = new IdentityRole("admin") { NormalizedName = "ADMIN" };
         var userRole = new IdentityRole("user") { NormalizedName = "USER" };
         var guestRole = new IdentityRole("guest") { NormalizedName = "GUEST" };
         builder.Entity<IdentityRole>().HasData(ownerRole, adminRole, userRole, guestRole);
      }
   }
}