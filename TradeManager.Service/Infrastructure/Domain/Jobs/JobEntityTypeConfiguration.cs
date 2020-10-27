using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeManager.Domain.Models.EventsLog;
using TradeManager.Service.Infrastructure.Database;

namespace TradeManager.Service.Infrastructure.Domain.Jobs
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
