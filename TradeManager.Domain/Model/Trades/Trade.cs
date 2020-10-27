using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TradeManager.Domain.Models.Trades
{
    public class Trade
    {
        [Key]
        public Guid Id { get; private set; }

        public DateTime Date { get; set; }

        public Guid ProductId { get; set; }

        public string Details { get; set; }

        public Guid SchemaId { get; set; }

        public Guid TradeId { get; set; }

        public Guid PortfolioId { get; set; }

        private Trade() { }

        private Trade(DateTime date, Guid productId, string details, Guid schemaId, Guid tradeId, Guid portfolioId)
        {
            Id = Guid.NewGuid();
            Date = date;
            ProductId = productId;
            Details = details;
            SchemaId = schemaId;
            TradeId = schemaId;
            PortfolioId = portfolioId;
        }
        
        public static Trade Create(DateTime date, Guid productId, string details, Guid schemaId, Guid tradeId, Guid portfolioId)
        {
            return new Trade( date,  productId,  details,  schemaId,  tradeId,  portfolioId);
        }

    }
}
