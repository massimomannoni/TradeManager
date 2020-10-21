using System;
using TradeManager.Service.SeedWork;
using TradeManager.Service.Models;

namespace TradeManager.Service.Domain.Trade
{
    public class  TradeRegisteredEvent : DomainEventBase
    {
        public Guid TradeId { get; }

        public TradeRegisteredEvent(Guid tradeId)
        {
            TradeId = tradeId;
        }
    }
}
