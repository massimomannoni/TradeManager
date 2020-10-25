using Autofac;
using MediatR;
using SampleProject.Application.Customers.IntegrationHandlers;
using System;
using System.Threading.Tasks;
using TradeManager.Domain.Models.Trades;
using TradeManager.Domain.SeedWork;
using TradeManager.Service.Infrastructure;
using TradeManager.Service.Infrastructure.Database;

namespace TradeManager.Service.Trades.CreateTrade
{
    public class ProductTradeService : Entity
    {

        private readonly UpsLightContext _context;
        private readonly Mediator _mediator;

        public ProductTradeService(UpsLightContext context)
        {
            _context = context;


            using (var scope = CompositionRoot.BeginLifetimeScope())
            {
                 _mediator = (Mediator)scope.Resolve<IMediator>();
            }
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

            TradeRegisteredNotification tradedeRegisteredNotification = new TradeRegisteredNotification(newTrade.Id);

            await _mediator.Publish(tradedeRegisteredNotification);

            return newTrade.Id;
        }

    }
}
