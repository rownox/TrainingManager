using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Data {
    public class WCSTrainerContext : DbContext {
        public WCSTrainerContext(DbContextOptions<WCSTrainerContext> options)
            : base(options) {
        }

        public DbSet<WebApplication2.Models.TrainingOrder> TrainingOrder { get; set; } = default!;
        public DbSet<WCSTrainer.Models.Employee> Employee { get; set; } = default!;
    }
}
