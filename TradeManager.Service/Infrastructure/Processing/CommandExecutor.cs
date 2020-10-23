﻿using Autofac;
using MediatR;
using System.Threading.Tasks;
using TradeManager.Service.Configuration.Commands;

namespace TradeManager.Service.Infrastructure.Processing
{
    public static class CommandExecutor
    {
        public static async Task Execute(ICommand command)
        {

            using (var scope = CompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                await mediator.Send(command);
            }
        }

        public static async Task<TResult> Execute<TResult>(ICommand<TResult> command)
        {
            using (var scope = CompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(command);
            }
        }
    }
}
