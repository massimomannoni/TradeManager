using Newtonsoft.Json;
using System;
using TradeManager.Service.Domain.Trade;
using TradeManager.Service.Domain.Events;

namespace TradeManager.Service.Trades.IntegrationHandlers
{
    public class TradeRegisteredNotification : DomainNotificationBase<TradeRegisteredEvent>
    {
        public Guid TradeId { get; }

        public TradeRegisteredNotification(TradeRegisteredEvent domainEvent) : base(domainEvent)
        {
            TradeId = domainEvent.TradeId;
        }

        [JsonConstructor]
        public TradeRegisteredNotification(Guid tradeId) : base(null)
        {
            TradeId = tradeId;
        }
    }
}