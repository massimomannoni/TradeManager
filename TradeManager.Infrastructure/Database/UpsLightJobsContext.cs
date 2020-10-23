using Microsoft.EntityFrameworkCore;
using System.Net;


namespace TradeManager.Infrastructure.Database
{
    public class UpsLightJobsContext : DbContext
    {
        //public DbSet<ProductTrade> ProductTrade { get; set; }

        //public DbSet<EventStore> EventStore { get; set; }

        protected UpsLightJobsContext() { }

        public UpsLightJobsContext(DbContextOptions options) : base(options)
        {

        }
    }
}
