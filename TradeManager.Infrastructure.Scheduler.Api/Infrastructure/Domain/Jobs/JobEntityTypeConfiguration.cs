using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeManager.Domain.Models.Jobs;

namespace TradeManager.Infrastructure.Scheduler.Database.Domain.Events
{
    internal sealed class JobEntityTypeConfiguration : IEntityTypeConfiguration<EventsLog>
    {
        public void Configure(EntityTypeBuilder<EventsLog> builder)
        {
            builder.ToTable("Jobs", Schemas.Event);

            builder.HasKey(b => b.Id);
        }
    }
}
