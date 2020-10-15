using Microsoft.EntityFrameworkCore;
using TradeManager.Service.Models;

namespace TradeManager.Service
{
    public class UpsLightContext : DbContext
    {
        public DbSet<ProductTrade> ProductTrade { get; set; }

        public UpsLightContext (DbContextOptions options) : base(options)
        {

        }
    }
}
