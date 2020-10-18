using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TradeManager.Service.Configuration.Processing;
using TradeManager.Service.DomainEvents.Trades;

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

            // 2) handles domain events raised

            await _commandsScheduler.EnqueueAsync(new TradeRegisteredCommand(Guid.NewGuid(), notification.Trade));
        }
    }
}