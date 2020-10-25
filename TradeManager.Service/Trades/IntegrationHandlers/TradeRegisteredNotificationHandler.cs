using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SampleProject.Application.Customers.IntegrationHandlers
{
    public class TradeRegisteredNotificationHandler : INotificationHandler<TradeRegisteredNotification>
    {
       

        public TradeRegisteredNotificationHandler( )
        {
           
        }

        public async Task Handle(TradeRegisteredNotification notification, CancellationToken cancellationToken)
        {
            
        }
    }
}