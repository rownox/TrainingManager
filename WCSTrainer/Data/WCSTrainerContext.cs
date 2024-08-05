using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Data {
  public class WCSTrainerContext : IdentityDbContext<UserAccount> {
    public WCSTrainerContext(DbContextOptions<WCSTrainerContext> options)
        : base(options) {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<TrainerGroup> TrainerGroups { get; set; }
    public DbSet<TrainingOrder> TrainingOrders { get; set; }
    public DbSet<Verification> Verifications { get; set; }

    protected override void OnModelCreating(ModelBuilder builder) {
      base.OnModelCreating(builder);

      builder.Entity<Employee>()
          .HasOne(e => e.UserAccount)
          .WithOne(u => u.Employee)
          .HasForeignKey<Employee>(e => e.UserAccountId);

      builder.Entity<Employee>()
          .HasMany(e => e.Skills)
          .WithMany(s => s.Employees);

      builder.Entity<TrainingOrder>()
          .HasOne(to => to.Trainee)
          .WithMany(e => e.TrainingOrdersAsTrainee)
          .HasForeignKey(to => to.TraineeId)
          .OnDelete(DeleteBehavior.Restrict);

      builder.Entity<TrainingOrder>()
          .HasMany(to => to.Trainers)
          .WithMany(e => e.TrainingOrdersAsTrainer)
          .UsingEntity(j => j.ToTable("TrainerTrainingOrders"));

      builder.Entity<TrainingOrder>()
          .HasOne(to => to.Location)
          .WithMany(l => l.TrainingOrders)
          .HasForeignKey(to => to.LocationId);

      builder.Entity<TrainingOrder>()
          .HasOne(to => to.Verification)
          .WithOne(v => v.TrainingOrder)
          .HasForeignKey<Verification>(v => v.TrainingOrderId);

      builder.Entity<TrainingOrder>()
          .HasMany(to => to.Skills)
          .WithMany(s => s.TrainingOrders)
          .UsingEntity<Dictionary<string, object>>(
              "TrainingOrderSkill",
              j => j
                  .HasOne<Skill>()
                  .WithMany()
                  .HasForeignKey("SkillId"),
              j => j
                  .HasOne<TrainingOrder>()
                  .WithMany()
                  .HasForeignKey("TrainingOrderId")
          );

      builder.Entity<TrainingOrder>()
          .HasMany(to => to.TrainerGroups)
          .WithMany(tg => tg.TrainingOrders)
          .UsingEntity(j => j.ToTable("TrainingOrderTrainerGroups"));

      builder.Entity<TrainerGroup>()
          .HasMany(tg => tg.Trainers)
          .WithMany()
          .UsingEntity(j => j.ToTable("TrainerGroupEmployees"));

      builder.Entity<Verification>()
          .HasOne(v => v.Verifier)
          .WithMany()
          .HasForeignKey(v => v.VerifierId);

      var adminRole = new IdentityRole("admin") { NormalizedName = "ADMIN" };
      var trainerRole = new IdentityRole("trainer") { NormalizedName = "TRAINER" };
      var traineeRole = new IdentityRole("trainee") { NormalizedName = "TRAINEE" };
      builder.Entity<IdentityRole>().HasData(adminRole, trainerRole, traineeRole);
    }
    public DbSet<WCSTrainer.Models.Person> Person { get; set; } = default!;
  }
}