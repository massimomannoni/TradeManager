using System;
using System.Collections.Generic;
using System.Text;

namespace TradeManager.Service.Model
{
    public class ProductTrade
    {
        public Guid Id { get; private set; }

        public string Name { get; set; }

        public int Type { get; set; }

        public string Details { get; set; }

        public Guid SchemaId { get; set; }

        public Guid PortfolioId { get; set; }

        public Trade(string name, int type, string details, Guid schemaId, Guid portfolioId)
        {
            Id = new Guid();
            Name = name;
            Type = type;
            Details = details;
            SchemaId = schemaId;
            PortfolioId = portfolioId;
        }

    }
}
