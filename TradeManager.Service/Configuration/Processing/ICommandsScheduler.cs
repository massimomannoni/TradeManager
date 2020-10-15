using System.Threading.Tasks;

using TradeManager.Service.Configuration.Commands;

namespace TradeManager.Service.Configuration.Processing
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync<T>(ICommand<T> command);
    }
}