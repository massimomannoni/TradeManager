using System.Reflection;

namespace TradeManager.Service.Infrastructure.Processing
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(CommandExecutor).Assembly;
    }
}