
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using TradeManager.Service.Domain.Trade;
using TradeManager.Service.Models;
using TradeManager.Service.SeedWork;

namespace TradeManager.Service.Trades.CreateTrade
{
    public class ProductTradeService : Entity
    {
        private readonly UpsLightContext _upsLightContext;
        public ProductTradeService(UpsLightContext upsLightContext)
        {
            _upsLightContext = upsLightContext;
        }
        public async Task<Guid> Create(ProductTrade newTrade)
        {
            // store the object
            _upsLightContext.ProductTrade.Add(newTrade);

            // raise domain events
            AddDomainEvent(new TradeRegisteredEvent(newTrade));

            return newTrade.Id;
        }

    }
}
