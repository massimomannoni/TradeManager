using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeManager.Domain.Models.EventsLog;
using TradeManager.Service.Infrastructure.Database;

namespace TradeManager.Service.Infrastructure.Domain.Jobs
{
    internal sealed class JobEntityTypeConfiguration : IEntityTypeConfiguration<EventLog>
    {
        public void Configure(EntityTypeBuilder<EventLog> builder)
        {
            builder.ToTable("Jobs", Schemas.Event);

            builder.HasKey(b => b.Id);
        }
    }
}
