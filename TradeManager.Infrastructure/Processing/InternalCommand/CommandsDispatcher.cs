﻿using System;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TradeManager.Infrastructure.Database;

namespace TradeManager.Infrastructure.Processing.InternalCommand
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