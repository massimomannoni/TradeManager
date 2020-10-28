using System;
using System.ComponentModel.DataAnnotations;

namespace TradeManager.Service.Trades.CreateTrade
{
    public class CreateTradeRequest
    {
 
        public CreateTradeRequest(DateTime date, Guid productId, string details, Guid schemaId, Guid tradeId, Guid portfolioId)
        {
            Date = date;
            ProductId = productId;
            Details = details;
            SchemaId = schemaId;
            TradeId = tradeId;
            PortfolioId = portfolioId;
        }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public Guid SchemaId { get; set; }

        [Required]
        public Guid TradeId { get; set; }

        [Required]
        public Guid PortfolioId { get; set; }
    }
}
