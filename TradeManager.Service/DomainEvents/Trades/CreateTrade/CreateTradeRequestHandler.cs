
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using TradeManager.Service.Domain.Trade;
using TradeManager.Service.DomainEvents.Trades;
using TradeManager.Service.Model;
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
           
            // 1) raise domain events
            AddDomainEvent(new TradeRegisteredEvent(newTrade.Id));

            // store the object
            await _context.ProductTrade.AddAsync(newTrade);

            await _context.SaveChangesAsync();

            var command =  new TradeRegisteredCommand(Guid.NewGuid(), newTrade.TradeId);

            var domainEvent = new EventStore();
            domainEvent.Id = command.Id;
            domainEvent.EnqueueDate = DateTime.UtcNow;
            domainEvent.Type = command.GetType().FullName;
            domainEvent.Data = JsonConvert.SerializeObject(command);

            await _context.EventStore.AddAsync(domainEvent);

            // save changes
            await _context.SaveChangesAsync();

            return newTrade.Id;
        }

    }
}
