using Coravel.Invocable;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TradeManager.Domain.Models.Events;
using TradeManager.Domain.Models.EventsLog;
using TradeManager.Domain.Models.Trades;

namespace TradeManager.Scheduler.Infrastructure.Database
{
    public class UpdateAnalytics : IInvocable
    {
        private readonly UpsLightJobContext _context;


        public UpdateAnalytics(UpsLightJobContext context)
        {
            _context = context;
        }

        public async Task Invoke()
        {

            // check if an event has been processed
            // get all events with occured date major of event processed date 
            // execute the logic

            var eventsProceded = await _context.EventsLog.ToListAsync();
            if (eventsProceded.Count < 1)
                await ProceedEventsAsync();

        }

        private async Task ProceedEventsAsync()
        {
            Type eventTypeToProcess = typeof(TradeRegisteredEvent);

            var eventsToProced = await _context.Events.Where(x => x.Type == eventTypeToProcess.FullName).OrderBy(d => d.Date).ToListAsync();

            foreach (Event eventToProced in eventsToProced)
            {
                // apply logic here



                ///

                EventLog log = EventLog.Create(eventToProced.Type, DateTime.UtcNow);

                await _context.EventsLog.AddAsync(log);

                await _context.SaveChangesAsync();
            }

        }
    }
}
