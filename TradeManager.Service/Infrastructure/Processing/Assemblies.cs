using System.Reflection;
using TradeManager.Service.Configuration.DomainEvents;

namespace TradeManager.Service.Infrastructure.Processing
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(IDomainEventNotification).Assembly;
    }
}