﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeManager.Domain.Models.Events;

namespace TradeManager.Scheduler.Infrastructure.Database.Domain.Events
{
    internal sealed class EventEntityTypeConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events", Schemas.Event);

            builder.HasKey(b => b.Id);



        }
    }
}