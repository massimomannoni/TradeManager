using Microsoft.EntityFrameworkCore;
using System.Net;
using TradeManager.Service.Models;

namespace TradeManager.Service
{
    public class UpsLightContext : DbContext
    {
        public DbSet<ProductTrade> ProductTrade { get; set; }

        protected UpsLightContext() { }
        public UpsLightContext (DbContextOptions options) : base(options)
        {

        }
    }
}
