using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeManager.Domain.Models.Events;

namespace TradeManager.Infrastructure.Scheduler.Database.Domain.Events
{
    internal sealed class EventEntityTypeConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("Events", Schemas.Event);

            builder.HasKey(b => b.Id);
        }
    }
}
