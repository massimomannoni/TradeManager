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
        public TradeRegisteredCommand(Guid id, ProductTrade trade) : base(id)
        {
            Trade = trade;
        }

        public ProductTrade Trade { get; }
    }
}
