﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using TradeManager.Service.Configuration.Commands;

namespace TradeManager.Service.Processing.Events
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
           

            return Unit.Value;
        }

        private class InternalCommandDto
        {
            public string Type { get; set; }

            public string Data { get; set; }
        }
    }
}