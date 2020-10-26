using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TradeManager.Service.Infrastructure.Database;
using TradeManager.Domain.Models.Events;
using Newtonsoft.Json;

namespace SampleProject.Application.Customers.IntegrationHandlers
{
    public class TradeRegisteredNotificationHandler : INotificationHandler<TradeRegisteredNotification>
    {
        private readonly UpsLightContext _context;

        public TradeRegisteredNotificationHandler(UpsLightContext context)
        {
            _context = context;
        }

        public async Task Handle(TradeRegisteredNotification notification, CancellationToken cancellationToken)
        {
            var eventNotification = Job.Create(DateTime.UtcNow, notification.DomainEvent.GetType().FullName, JsonConvert.SerializeObject(notification.DomainEvent));

            await _context.Event.AddAsync(eventNotification);

            await _context.SaveChangesAsync();
        }
    }
}