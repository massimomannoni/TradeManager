using System;
using System.Threading.Tasks;

namespace TradeManager.Service.Processing
{
    public interface ICommandsDispatcher
    {
        Task DispatchCommandAsync(Guid id);
    }
}
