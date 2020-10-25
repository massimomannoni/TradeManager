using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using TradeManager.Domain.Models;
using TradeManager.Domain.SeedWork;
using TradeManager.Service.Domain.Trade;
using TradeManager.Service.Infrastructure.Database;

namespace TradeManager.Service.Trades.CreateTrade
{
    public class ProductTradeService : Entity
    {

        private readonly UpsLightContext _context;

        public ProductTradeService(UpsLightContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(Trade newTrade)
        {

            // 1) raise domain events
            //AddDomainEvent(new TradeRegisteredEvent(newTrade.Id));

            // store the object
            await _context.Trade.AddAsync(newTrade);

            //var command =  new TradeRegisteredCommand(Guid.NewGuid(), newTrade.TradeId);

            //var domainEvent = new EventStore();
            //domainEvent.Id = command.Id;
            //domainEvent.EnqueueDate = DateTime.UtcNow;
            //domainEvent.Type = command.GetType().FullName;
            //domainEvent.Data = JsonConvert.SerializeObject(command);

            // await _context.EventStore.AddAsync(domainEvent);

            // save changes
            await _context.SaveChangesAsync();

            return newTrade.Id;
        }

    }
}
