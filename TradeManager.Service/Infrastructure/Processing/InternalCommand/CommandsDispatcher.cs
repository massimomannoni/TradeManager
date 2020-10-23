using System;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using TradeManager.Service.Infrastructure.Database;

namespace TradeManager.Servuce.Infrastructure.Processing.InternalCommand
{
    public class CommandsDispatcher : ICommandsDispatcher
    {
        private readonly IMediator _mediator;
        private readonly UpsLightContext _context;

        public CommandsDispatcher( IMediator mediator, UpsLightContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task DispatchCommandAsync(Guid id)
        {
            // get internal commands using context and send it using the mediator
         
        }
    }
}