using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WCSTrainer.Data
{
    public class WCSTrainerContext : DbContext
    {
        public WCSTrainerContext (DbContextOptions<WCSTrainerContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication2.Models.TrainingOrder> TrainingOrder { get; set; } = default!;
    }
}
