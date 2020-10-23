using System.Reflection;
using TradeManager.Service.DomainEvents.Trades;

namespace TradeManager.Service.Processing
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(TradeRegisteredCommand).Assembly;
    }
}