using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TradeManager.Service.Models
{
    public class ProductTrade
    {
        [Key]
        public Guid Id { get; private set; }

        public DateTime Date { get; set; }

        public Guid ProductId { get; set; }

        public string Details { get; set; }

        public Guid SchemaId { get; set; }

        public Guid TradeId { get; set; }

        public Guid PortfolioId { get; set; }

        public ProductTrade(DateTime date, Guid productId, string details, Guid schemaId, Guid tradeId, Guid portfolioId)
        {
            Id = new Guid();
            Date = date;
            ProductId = productId;
            Details = details;
            SchemaId = schemaId;
            TradeId = schemaId;
            PortfolioId = portfolioId;
        }

    }
}
