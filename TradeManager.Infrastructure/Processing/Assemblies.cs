﻿using System.Reflection;
using TradeManager.Service.DomainEvents.Trades;

namespace TradeManager.Infrastructure.Processing
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(TradeRegisteredCommand).Assembly;
    }
}