using System.Reflection;
using TradeManager.Domain.Models.Trades;

namespace TradeManager.Scheduler.Infrastructure.Database
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(TradeRegisteredEvent).Assembly;
    }
}