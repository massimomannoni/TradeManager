using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

using System.Threading.Tasks;
using TradeManager.Service.Domain.Trade;
using TradeManager.Service.Models;
using TradeManager.Service.SeedWork;

namespace TradeManager.Service.Trades.CreateTrade
{
    public class ProductTradeService : Entity
    {
        private readonly DbContext _dbContext;
        public ProductTradeService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Create()
        {

            var newTrade = new ProductTrade(request.Name, request.Type, request.Details, request.SchemaId, request.PortfolioId);

            await _dbContext.AddAsync(newTrade);

            AddDomainEvent(new TradeRegisteredEvent(newTrade));

            return newTrade.Id;
        }

    }
}
