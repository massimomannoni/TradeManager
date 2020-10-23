using Microsoft.EntityFrameworkCore;
using System.Net;
using TradeManager.Service.Model;
using TradeManager.Service.Models;

namespace TradeManager.Infrastructure.Database
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
