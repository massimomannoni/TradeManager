using System;
using TradeManager.Service.SeedWork;
using TradeManager.Service.Models;

namespace TradeManager.Service.Domain.Trade
{
    public class  TradeRegisteredEvent : DomainEventBase
    {
        public ProductTrade Trade { get; }

        public TradeRegisteredEvent(ProductTrade trade)
        {
            Trade = trade;
        }
    }
}
