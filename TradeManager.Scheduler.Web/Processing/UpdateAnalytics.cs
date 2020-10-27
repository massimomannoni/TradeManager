using Coravel.Invocable;
using Coravel.Pro.Features.Resources.Fields;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradeManager.Domain.Models.Events;
using TradeManager.Domain.Models.EventsLog;
using TradeManager.Domain.Models.Trades;

namespace TradeManager.Scheduler.Infrastructure.Database
{
    public class UpdateAnalytics : IInvocable
    {
        private readonly UpsLightJobContext _context;
        private readonly Type eventTypeToProcess = typeof(TradeRegisteredEvent);

        public UpdateAnalytics(UpsLightJobContext context)
        {
            _context = context;
        }

        public async Task Invoke()
        {
            // check if an event has been processed
            // get all events with occured date major of event processed date 
            // execute the logic

            var eventsProcessed = await _context.EventsLog.ToListAsync();
            if (eventsProcessed.Count < 1)
            {
                await ProcessAllEvents();
            }
            else
            {
                await ProcessLastEvent();
            }
        }


        private async Task ProcessLastEvent()
        {
            var lastEventProcessed = await _context.EventsLog.Where(x => x.Type == eventTypeToProcess.FullName).OrderByDescending(d => d.ProcessedDate).FirstOrDefaultAsync();
            
            var eventsToProced = await _context.Events.Where(x => x.Type == eventTypeToProcess.FullName && x.Date >= lastEventProcessed.ProcessedDate).OrderBy(d => d.Date).ToListAsync();
            
            await UpdateLogs(eventsToProced);

            eventsToProced = null;

        }

        private async Task ProcessAllEvents()
        {

            var eventsToProced = await _context.Events.Where(x => x.Type == eventTypeToProcess.FullName).OrderBy(d => d.Date).ToListAsync();

            await UpdateLogs(eventsToProced);

            eventsToProced = null;
        }

        private async Task UpdateLogs(List<Event> events)
        {
            if (events.Count < 1)
                return;

            foreach (Event eventToProced in events)
            {
                // apply logic here

                Thread.Sleep(2000);
                ///

                EventLog log = EventLog.Create(eventToProced.Type, System.DateTime.UtcNow);

                await _context.EventsLog.AddAsync(log);

                await _context.SaveChangesAsync();
            }
        }
    }
}
