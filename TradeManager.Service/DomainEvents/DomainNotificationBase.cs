using System;
using Newtonsoft.Json;
using TradeManager.Service.Configuration.DomainEvents;

namespace TradeManager.Service.Domain.Events
{
    public class DomainNotificationBase<T> : IDomainEventNotification<T> where T : IDomainEvent
    {
 
        [JsonIgnore]
        public T DomainEvent { get; }

        public Guid Id { get; }

        public DomainNotificationBase(T domainEvent)
        {
            Id = Guid.NewGuid();
            DomainEvent = domainEvent;
        }
    }
}