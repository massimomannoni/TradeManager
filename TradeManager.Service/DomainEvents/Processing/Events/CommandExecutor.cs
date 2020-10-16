﻿using MediatR;
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
            // from container, then
            // use the mediator to send the commands
            // the commands (ask a classes) are managed by an handler
            // 

            // that means we need to inject into service project all dependencies we need
           
        }
    }
}
