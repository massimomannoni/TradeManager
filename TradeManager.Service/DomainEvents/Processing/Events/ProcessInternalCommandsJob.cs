using System.Threading.Tasks;
using Quartz;

namespace TradeManager.Service.Processing.Events
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