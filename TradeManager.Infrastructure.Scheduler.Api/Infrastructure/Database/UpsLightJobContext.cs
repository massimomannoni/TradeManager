using Microsoft.EntityFrameworkCore;
using System.Net;
using TradeManager.Domain.Models;


namespace TradeManager.Infrastructure.Scheduler.Database
{
    public class UpsLightJobContext : DbContext
    {
        public DbSet<EventStore> EventStore { get; set; }

        protected UpsLightJobContext() { }

        public UpsLightJobContext (DbContextOptions options) : base(options)
        {

        }
    }
}
