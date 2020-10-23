using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TradeManager.Service.Domain.Trade;

namespace TradeManager.Service.DomainEvents.Trades.IntegrationHandlers
{
  
        public class TradeRegisteredEventHandler : INotificationHandler<TradeRegisteredEvent>
        {
      

            public TradeRegisteredEventHandler()
            {
                
            }

            public async Task Handle(TradeRegisteredEvent notification, CancellationToken cancellationToken)
            {

               // handler

              // opt1 call RestApi
            }

    }
    
}
