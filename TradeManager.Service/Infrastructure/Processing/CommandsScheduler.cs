using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using TradeManager.Domain.Models;
using TradeManager.Service.Configuration.Commands;
using TradeManager.Service.Configuration.Processing;
using TradeManager.Service.Infrastructure.Database;

namespace TradeManager.Servuce.Infrastructure.Processing
{

    // verify context injection
    public class CommandsScheduler : ICommandsScheduler
    {
        private readonly UpsLightContext _context;
        public CommandsScheduler(UpsLightContext context)
        {
            _context = context;
        }
        public async Task EnqueueAsync<T>(ICommand<T> command)
        {
            // 3) domain events persistance handler

            var domainEvent = new EventStore();
            domainEvent.Id = command.Id;
            domainEvent.EnqueueDate = DateTime.UtcNow;
            domainEvent.Type = command.GetType().FullName;
            domainEvent.Data = JsonConvert.SerializeObject(command);

            await _context.EventStore.AddAsync(domainEvent);

            await _context.SaveChangesAsync();
            
        }
    }
}
