using System;
using System.Threading.Tasks;

namespace TradeManager.Service.Infrastructure.Processing
{
    public interface ICommandsDispatcher
    {
        Task DispatchCommandAsync(Guid id);
    }
}
