using System;
using System.ComponentModel.DataAnnotations;

namespace TradeManager.Service.Trades.CreateTrade
{
    public class CreateTradeRequest
    {
        private Guid productId1;
        private Guid productId2;

        public CreateTradeRequest(DateTime date, Guid productId1, string details, Guid schemaId, Guid tradeId, Guid productId2)
        {
            Date = date;
            this.productId1 = productId1;
            Details = details;
            SchemaId = schemaId;
            TradeId = tradeId;
            this.productId2 = productId2;
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
