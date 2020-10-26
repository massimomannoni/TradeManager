using Microsoft.EntityFrameworkCore;
using System.Net;
using TradeManager.Domain.Models;
using TradeManager.Domain.Models.Events;

namespace TradeManager.Infrastructure.Scheduler.Database
{
    public class UpsLightJobContext : DbContext
    {
        public DbSet<Event> Event { get; set; }

        protected UpsLightJobContext() { }

        public UpsLightJobContext (DbContextOptions options) : base(options)
        {

        }
    }
}
