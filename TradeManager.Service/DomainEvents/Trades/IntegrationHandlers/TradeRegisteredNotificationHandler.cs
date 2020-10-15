using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TradeManager.Service.Configuration.Processing;

namespace TradeManager.Service.Trades.IntegrationHandlers
{
    public class TradeRegisteredNotificationHandler : INotificationHandler<TradeRegisteredNotification>
    {
        private readonly ICommandsScheduler _commandsScheduler;

        public TradeRegisteredNotificationHandler(ICommandsScheduler commandsScheduler)
        {
            _commandsScheduler = commandsScheduler;
        }

        public async Task Handle(TradeRegisteredNotification notification, CancellationToken cancellationToken)
        {
            // add command to process to queue
            // need to implement consumer or process the queue

           // await _commandsScheduler.EnqueueAsync();
        }
    }
}