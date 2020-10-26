using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeManager.Domain.Models;
using TradeManager.Domain.Models.Events;
using TradeManager.Domain.Models.Trades;
using TradeManager.Service.Infrastructure.Database;

namespace TradeManager.Service.Infrastructure.Domain.Events
{
    internal sealed class EventEntityTypeConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events", Schemas.Trade);

            builder.HasKey(b => b.Id);
        }
    }
}
