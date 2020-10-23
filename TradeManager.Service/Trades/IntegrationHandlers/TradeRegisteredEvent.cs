using System;
using TradeManager.Domain.SeedWork;

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
