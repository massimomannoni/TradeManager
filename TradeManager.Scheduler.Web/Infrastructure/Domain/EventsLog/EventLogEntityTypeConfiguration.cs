using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeManager.Domain.Models.EventsLog;

namespace TradeManager.Scheduler.Infrastructure.Database.Domain.Jobs
{
    internal sealed class EventLogEntityTypeConfiguration : IEntityTypeConfiguration<EventLog>
    {
        public void Configure(EntityTypeBuilder<EventLog> builder)
        {
            builder.ToTable("EventsLog", Schemas.Event);

            builder.HasKey(b => b.Id);
        }
    }
}
