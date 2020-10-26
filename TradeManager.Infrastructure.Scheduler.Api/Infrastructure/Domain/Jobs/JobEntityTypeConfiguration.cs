using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeManager.Domain.Models.Jobs;

namespace TradeManager.Infrastructure.Scheduler.Database.Domain.Events
{
    internal sealed class JobEntityTypeConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("Jobs", Schemas.Event);

            builder.HasKey(b => b.Id);
        }
    }
}
