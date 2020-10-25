using Coravel.Invocable;
using MediatR;
using System;
using System.Collections.Generic;
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

        public Task Invoke()
        {
            // write here the logic ;)
            return Unit.Task;
        }
    }
}
