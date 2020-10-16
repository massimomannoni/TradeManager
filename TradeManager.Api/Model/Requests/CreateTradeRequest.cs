using System;
using System.ComponentModel.DataAnnotations;

namespace TradeManager.Api.Model.Requests
{
    public class CreateTradeRequest
    {
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
