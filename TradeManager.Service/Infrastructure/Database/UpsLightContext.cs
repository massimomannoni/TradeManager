using Microsoft.EntityFrameworkCore;

using TradeManager.Domain.Models.Trades;

namespace TradeManager.Service.Infrastructure.Database
{
    public class UpsLightContext : DbContext
    {
        public DbSet<Trade> Trade { get; set; }

       // public DbSet<EventStore> EventStore { get; set; }

        protected UpsLightContext() { }

        public UpsLightContext (DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.HasDefaultSchema("Trade");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UpsLightContext).Assembly);
        }
    }
}
