using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Models;

namespace WCSTrainer.Data {
    public class IdentityContext : IdentityDbContext<UserAccount> {
        
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            var trainer = new IdentityRole("trainer");
            trainer.NormalizedName = "trainer";

            var trainee = new IdentityRole("trainee");
            trainee.NormalizedName = "trainee";

            builder.Entity<IdentityRole>().HasData(admin, trainee, trainer);
        }
    }
}
