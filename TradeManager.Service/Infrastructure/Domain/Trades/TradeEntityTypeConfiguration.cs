using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeManager.Domain.Models;
using TradeManager.Domain.Models.Trades;
using TradeManager.Service.Infrastructure.Database;

namespace TradeManager.Service.Infrastructure.Domain.Trades
{
    internal sealed class EventEntityTypeConfiguration : IEntityTypeConfiguration<Trade>
    {
        public void Configure(EntityTypeBuilder<Trade> builder)
        {
            builder.ToTable("Trades", Schemas.Trade);

            builder.HasKey(b => b.Id);
        }
    }
}
