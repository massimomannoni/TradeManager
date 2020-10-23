using Microsoft.EntityFrameworkCore;
using System.Net;
using TradeManager.Domain.Models;


namespace TradeManager.Service.Infrastructure.Database
{
    public class UpsLightContext : DbContext
    {
        public DbSet<ProductTrade> ProductTrade { get; set; }

        public DbSet<EventStore> EventStore { get; set; }

        protected UpsLightContext() { }

        public UpsLightContext (DbContextOptions options) : base(options)
        {

        }
    }
}
