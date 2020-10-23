using System.Threading.Tasks;
using Quartz;

namespace TradeManager.Servuce.Infrastructure.Processing.InternalCommand
{
    [DisallowConcurrentExecution]
    public class ProcessInternalCommandsJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await CommandExecutor.Execute(new ProcessInternalCommandsCommand());
        }
    }
}