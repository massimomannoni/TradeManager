using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TradeManager.Service.Configuration.Commands;
using TradeManager.Service.DomainEvents.Trades;

namespace TradeManager.Service.Trades.IntegrationHandlers
{
    public class TradeRegisteredCommandHandler : ICommandHandler<TradeRegisteredCommand, Unit>
    {
        private readonly UpsLightContext _context;

        public TradeRegisteredCommandHandler(UpsLightContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(TradeRegisteredCommand command, CancellationToken cancellationToken)
        {
            // do something here whit your command yeahhh ;)

            return Unit.Value;
        }
    }
}