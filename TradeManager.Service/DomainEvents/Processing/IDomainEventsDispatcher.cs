using System.Threading.Tasks;

namespace TradeManager.Service.Processing
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchEventsAsync();
    }
}