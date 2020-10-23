﻿using System.Threading.Tasks;

namespace TradeManager.Infrastructure.Processing
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchEventsAsync();
    }
}