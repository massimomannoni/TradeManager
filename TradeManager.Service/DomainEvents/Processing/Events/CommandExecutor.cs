using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TradeManager.Service.Configuration.Commands;

namespace TradeManager.Service.DomainEvents.Processing.Events
{
    public static class CommandExecutor
    {
        public static async Task Execute(ICommand command)
        {
            // need to resolve the IMediator
            // use the mediator to send the command
           
        }
    }
}
