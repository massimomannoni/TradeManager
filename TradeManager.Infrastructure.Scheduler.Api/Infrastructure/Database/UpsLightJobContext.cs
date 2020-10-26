using Microsoft.EntityFrameworkCore;
using TradeManager.Domain.Models.Jobs;

namespace TradeManager.Infrastructure.Scheduler.Database
{
    public class UpsLightJobContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }

        protected UpsLightJobContext() { }

        public UpsLightJobContext (DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
   
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UpsLightJobContext).Assembly);
        }
    }
}
