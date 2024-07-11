using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WCSTrainer.Models;
using Microsoft.AspNetCore.Identity;

namespace WCSTrainer.Data {
    public class WCSTrainerContext : IdentityDbContext<UserAccount> {
        public WCSTrainerContext(DbContextOptions<WCSTrainerContext> options)
            : base(options) {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<TrainerGroup> TrainerGroups { get; set; }
        public DbSet<TrainingOrder> TrainingOrders { get; set; }
        public DbSet<Verification> Verifications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            // UserAccount and Employee relationship
            builder.Entity<Employee>()
                .HasOne(e => e.User)
                .WithOne(u => u.Employee)
                .HasForeignKey<Employee>(e => e.UserId);

            // TrainerGroup and Employee relationship (many-to-many)
            builder.Entity<Employee>()
                .HasMany(e => e.TrainerGroups)
                .WithMany(tg => tg.Trainers)
                .UsingEntity(j => j.ToTable("EmployeeTrainerGroups"));

            // TrainingOrder and Employee relationships (many-to-many)
            builder.Entity<TrainingOrder>()
                .HasMany(to => to.Trainers)
                .WithMany(e => e.TrainingOrders)
                .UsingEntity(j => j.ToTable("TrainingOrderTrainers"));

            builder.Entity<TrainingOrder>()
                .HasOne(to => to.Trainee)
                .WithMany()
                .HasForeignKey(to => to.TraineeId);

            // Verification and TrainingOrder relationship (one-to-one)
            builder.Entity<Verification>()
                .HasOne(v => v.TrainingOrder)
                .WithOne(to => to.Verification)
                .HasForeignKey<Verification>(v => v.TrainingOrderId);

            var adminRole = new IdentityRole("admin") { NormalizedName = "ADMIN" };
            var trainerRole = new IdentityRole("trainer") { NormalizedName = "TRAINER" };
            var traineeRole = new IdentityRole("trainee") { NormalizedName = "TRAINEE" };

            builder.Entity<IdentityRole>().HasData(adminRole, trainerRole, traineeRole);
        }
    }
}
