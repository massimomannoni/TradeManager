using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using TradeManager.Service.Configuration.Commands;
using TradeManager.Service.Infrastructure.Database;

namespace TradeManager.Servuce.Infrastructure.Processing.InternalCommand
{
    internal class ProcessInternalCommandsCommandHandler : ICommandHandler<ProcessInternalCommandsCommand, Unit>
    {
        private readonly UpsLightContext _context;

        public ProcessInternalCommandsCommandHandler(UpsLightContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ProcessInternalCommandsCommand command, CancellationToken cancellationToken)
        {

            // get events(commands) to be processed
            // invoke executor passing the payload

            var commandList = _context.EventStore.Where(x => x.ProcessedDate == null);


            foreach (var item in commandList)
            {
                // invoke command executor
                Type type = Assemblies.Application.GetType(item.Type);
                dynamic commandToProcess = JsonConvert.DeserializeObject(item.Data, type);

                await CommandExecutor.Execute(commandToProcess);
            }

            return Unit.Value;
        }

        private class InternalCommandDto
        {
            public string Type { get; set; }

            public string Data { get; set; }
        }
    }
}