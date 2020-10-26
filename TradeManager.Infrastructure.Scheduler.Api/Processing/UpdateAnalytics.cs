using Coravel.Invocable;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeManager.Domain.Models.Jobs;
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
            Job firstJobInQueue = _context.Jobs.Where(x => x.EnqueueDate == null).FirstAsync().Result;


            /// do something
            /// 
            firstJobInQueue.ProcessedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();


           
        }
    }
}
