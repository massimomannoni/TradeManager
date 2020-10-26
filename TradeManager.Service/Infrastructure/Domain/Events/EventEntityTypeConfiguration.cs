﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeManager.Domain.Models;
using TradeManager.Domain.Models.Events;
using TradeManager.Domain.Models.Trades;
using TradeManager.Service.Infrastructure.Database;

namespace TradeManager.Service.Infrastructure.Domain.Events
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
