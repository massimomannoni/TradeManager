using System;
using MediatR;

namespace TradeManager.Service.Configuration.DomainEvents
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}