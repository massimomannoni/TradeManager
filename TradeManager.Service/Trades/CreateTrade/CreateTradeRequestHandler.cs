﻿using MediatR;
using System;
using System.Threading.Tasks;
using TradeManager.Domain.Models.Trades;
using TradeManager.Domain.SeedWork;
using TradeManager.Service.Infrastructure.Database;

namespace TradeManager.Service.Trades.CreateTrade
{
    public class ProductTradeService : Entity
    {

        private readonly UpsLightContext _context;

        public ProductTradeService(UpsLightContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(CreateTradeRequest request)
        {

            // using request, create a domain/model object
            var newTrade = new Trade(request.Date, request.ProductId, request.Details, request.SchemaId, request.TradeId, request.PortfolioId);
            
            // store the object
            await _context.Trade.AddAsync(newTrade);

            // save changes
            await _context.SaveChangesAsync();

            // creatre and domain event

            TradeRegisteredEvent tradeRegisteredEvent = new TradeRegisteredEvent(newTrade.Id);

            // send domain event
           // await _mediator.Publish(tradeRegisteredEvent);

            return newTrade.Id;
        }

    }
}
