
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using TradeManager.Service.Domain.Trade;
using TradeManager.Service.Models;
using TradeManager.Service.SeedWork;

namespace TradeManager.Service.Trades.CreateTrade
{
    public class ProductTradeService : Entity
    {

        private readonly UpsLightContext _context;

        public ProductTradeService(UpsLightContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(ProductTrade newTrade)
        {
            // store the object
            await _context.ProductTrade.AddAsync(newTrade);

            // save changes
            await _context.SaveChangesAsync();
    
            // 1) raise domain events
            AddDomainEvent(new TradeRegisteredEvent(newTrade));

            return newTrade.Id;
        }

    }
}
