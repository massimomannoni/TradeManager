using System.Threading.Tasks;

namespace TradeManager.Servuce.Infrastructure.Processing
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchEventsAsync();
    }
}