using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WCSTrainer.Models;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;

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

            // Employee
            builder.Entity<Employee>()
                .HasOne<UserAccount>()
                .WithOne(u => u.Employee)
                .HasForeignKey<Employee>(e => e.UserId);

            builder.Entity<Employee>()
                .Property(e => e.SkillIds)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());

            builder.Entity<Employee>()
                .Property(e => e.TrainingOrderIds)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());

            // TrainerGroup
            builder.Entity<TrainerGroup>()
                .Property(tg => tg.TrainerIds)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());

            // TrainingOrder
            builder.Entity<TrainingOrder>()
                .HasOne<Employee>()
                .WithMany()
                .HasForeignKey(to => to.TraineeId);

            builder.Entity<TrainingOrder>()
                .HasOne<Location>()
                .WithMany()
                .HasForeignKey(to => to.LocationId);

            builder.Entity<TrainingOrder>()
                .HasOne<Verification>()
                .WithOne()
                .HasForeignKey<TrainingOrder>(to => to.VerificationId);

            builder.Entity<TrainingOrder>()
                .Property(to => to.TrainerIds)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());

            // Verification
            builder.Entity<Verification>()
                .HasOne<Employee>()
                .WithMany()
                .HasForeignKey(v => v.VerifierId);

            builder.Entity<Verification>()
                .HasOne<TrainingOrder>()
                .WithOne()
                .HasForeignKey<Verification>(v => v.TrainingOrderId);


            var adminRole = new IdentityRole("admin") { NormalizedName = "ADMIN" };
            var trainerRole = new IdentityRole("trainer") { NormalizedName = "TRAINER" };
            var traineeRole = new IdentityRole("trainee") { NormalizedName = "TRAINEE" };
            builder.Entity<IdentityRole>().HasData(adminRole, trainerRole, traineeRole);
        }
    }
}