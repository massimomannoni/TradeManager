using Coravel.Invocable;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TradeManager.Infrastructure.Scheduler.Database;

namespace TradeManager.Infrastructure.Scheduler.Api.Processing
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
            var jobInQueue = _context.Jobs.Where(x => x.ProcessedDate == null).Count();

            if (jobInQueue < 1)
                return;

            var jobToProceed = await _context.Jobs.Where(x => x.ProcessedDate == null).OrderBy(d => d.EnqueueDate).FirstOrDefaultAsync();


            // do something here


            // when finished update the processDate
            jobToProceed.ProcessedDate = DateTime.UtcNow;


            //save a baci&abbracci ;)
           await _context.SaveChangesAsync();

        }
    }
}
