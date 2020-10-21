using MediatR;
using Newtonsoft.Json;
using System;
using TradeManager.Service.Configuration.Commands;
using TradeManager.Service.Models;

namespace TradeManager.Service.DomainEvents.Trades
{
    public class TradeRegisteredCommand : InternalCommandBase<Unit>
    {
        [JsonConstructor]
        public TradeRegisteredCommand(Guid id, Guid tradeId) : base(id)
        {
            TradeId = tradeId;
        }

        public Guid TradeId { get; }
    }
}
