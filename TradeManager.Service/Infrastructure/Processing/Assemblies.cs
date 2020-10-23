using System.Reflection;

namespace TradeManager.Servuce.Infrastructure.Processing
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(TradeRegisteredCommand).Assembly;
    }
}