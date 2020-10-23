using System;
using System.Threading.Tasks;

namespace TradeManager.Servuce.Infrastructure.Processing
{
    public interface ICommandsDispatcher
    {
        Task DispatchCommandAsync(Guid id);
    }
}
