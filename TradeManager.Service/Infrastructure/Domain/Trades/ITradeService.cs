using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TradeManager.Service.Trades.CreateTrade;

namespace TradeManager.Service.Infrastructure.Domain.Trades
{
    public interface ITradeService
    {
        Task<Guid> Create(CreateTradeRequest trade);

    }
    
}
