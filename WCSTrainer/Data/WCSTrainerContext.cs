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

            // UserAccount - Employee relationship
            builder.Entity<UserAccount>()
                .HasOne(u => u.Employee)
                .WithOne(e => e.User)
                .HasForeignKey<Employee>(e => e.UserId);

            // Employee - TrainerGroup many-to-many relationship
            builder.Entity<Employee>()
                .HasMany(e => e.TrainerGroups)
                .WithMany(g => g.Trainers)
                .UsingEntity(j => j.ToTable("EmployeeTrainerGroups"));

            // TrainingOrder - Employee (Trainee) relationship
            builder.Entity<TrainingOrder>()
                .HasOne(to => to.Trainee)
                .WithMany(e => e.TrainingOrders)
                .HasForeignKey(to => to.TraineeId)
                .OnDelete(DeleteBehavior.Restrict);

            // TrainingOrder - Employee (Trainers) many-to-many relationship
            builder.Entity<TrainingOrder>()
                .HasMany(to => to.Trainers)
                .WithMany()
                .UsingEntity(j => j.ToTable("TrainingOrderTrainers"));

            // TrainingOrder - Verification one-to-one relationship
            builder.Entity<TrainingOrder>()
                .HasOne(to => to.Verification)
                .WithOne(v => v.TrainingOrder)
                .HasForeignKey<Verification>(v => v.TrainingOrderId);

            // Verification - Employee (Verifier) relationship
            builder.Entity<Verification>()
                .HasOne(v => v.Verifier)
                .WithMany()
                .HasForeignKey(v => v.VerifierId)
                .OnDelete(DeleteBehavior.Restrict);

            // TrainingOrder - Location relationship
            builder.Entity<TrainingOrder>()
                .HasOne(to => to.LocationObject)
                .WithMany()
                .HasForeignKey(to => to.LocationId);

            // Seed roles
            var adminRole = new IdentityRole("admin") { NormalizedName = "ADMIN" };
            var trainerRole = new IdentityRole("trainer") { NormalizedName = "TRAINER" };
            var traineeRole = new IdentityRole("trainee") { NormalizedName = "TRAINEE" };
            builder.Entity<IdentityRole>().HasData(adminRole, trainerRole, traineeRole);
        }
    }
}