using System;
using TradeManager.Service.Configuration.DomainEvents;

namespace TradeManager.Service.SeedWork
{
    public class DomainEventBase : IDomainEvent
    {
        public DomainEventBase()
        {
            OccurredOn = DateTime.Now;
        }

        public DateTime OccurredOn { get; }
    }
}