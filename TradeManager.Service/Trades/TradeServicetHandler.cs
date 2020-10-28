﻿using Autofac;
using MediatR;
using SampleProject.Application.Customers.IntegrationHandlers;
using System;
using System.Threading.Tasks;
using TradeManager.Domain.Models.Trades;
using TradeManager.Service.Infrastructure;
using TradeManager.Service.Infrastructure.Database;
using TradeManager.Service.Infrastructure.Domain.Trades;
using TradeManager.Service.Trades.CreateTrade;

namespace TradeManager.Service.Trades
{
    public class TradeServiceHandler : ITradeService
    {

        private readonly UpsLightContext _context;

        public TradeServiceHandler(UpsLightContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(CreateTradeRequest request)
        {

            // using request, create a domain/model object
            var newTrade = Trade.Create(request.Date, request.ProductId, request.Details, request.SchemaId, request.TradeId, request.PortfolioId);
            
            // store the object
            await _context.Trade.AddAsync(newTrade);

            // save changes
            await _context.SaveChangesAsync();

            // creatre and domain event

            TradeRegisteredEvent tradeRegisteredEvent = new TradeRegisteredEvent(newTrade.Id);

            TradeRegisteredNotification tradedeRegisteredNotification = new TradeRegisteredNotification(tradeRegisteredEvent);

            // find alternative
            using (var scope = CompositionRoot.BeginLifetimeScope())
            {
                var mediator = (Mediator)scope.Resolve<IMediator>();
                await mediator.Publish(tradedeRegisteredNotification);
            }
     
            return newTrade.Id;

        }
    }
}
