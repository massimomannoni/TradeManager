using Coravel.Invocable;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

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

            var lastEventProcessed = _context.EventsLog.Where(x => x.ProcessedDate == null).Count();

        

            var jobToProceed = await _context.EventsLog.Where(x => x.ProcessedDate == null).OrderBy(d => d.EnqueueDate).FirstOrDefaultAsync();


            // do something here
            // update analytics

            ///


            // when finished update the processDate
            jobToProceed.ProcessedDate = DateTime.UtcNow;


            //save a baci&abbracci ;)
           await _context.SaveChangesAsync();

        }
    }
}
