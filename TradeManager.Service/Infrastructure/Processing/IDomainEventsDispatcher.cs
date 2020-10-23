using System.Threading.Tasks;

namespace TradeManager.Service.Infrastructure.Processing
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchEventsAsync();
    }
}