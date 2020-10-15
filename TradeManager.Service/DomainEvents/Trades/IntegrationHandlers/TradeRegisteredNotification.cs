using Newtonsoft.Json;
using System;
using TradeManager.Service.Domain.Trade;
using TradeManager.Service.Models;
using TradeManager.Service.Domain.Events;

namespace TradeManager.Service.Trades.IntegrationHandlers
{
    public class TradeRegisteredNotification : DomainNotificationBase<TradeRegisteredEvent>
    {
        public ProductTrade Trade { get; }

        public TradeRegisteredNotification(TradeRegisteredEvent domainEvent) : base(domainEvent)
        {
            Trade = domainEvent.Trade;
        }

        [JsonConstructor]
        public TradeRegisteredNotification(ProductTrade trade) : base(null)
        {
            Trade = trade;
        }
    }
}