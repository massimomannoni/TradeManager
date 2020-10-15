using Microsoft.EntityFrameworkCore;
using TradeManager.Application.Models.Trades;

namespace TradeManager.Service.
{
    public class UpsLightContext : DbContext
    {
        public DbSet<Trade> Trade { get; set; }

        public UpsLightContext (DbContextOptions options) : base(options)
        {

        }
    }
}
