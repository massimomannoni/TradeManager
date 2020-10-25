using System;
using System.Collections.Generic;
using System.Text;
using TradeManager.Domain.SeedWork;

namespace TradeManager.Domain.Models.Trades
{
    public class TradeRegisteredEvent : DomainEventBase
    {
        public Guid TradeId { get;  }

        public TradeRegisteredEvent(Guid id)
        {
            TradeId = id;
        }

    }
}
