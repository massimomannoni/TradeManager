using System;
using System.Collections.Generic;
using System.Text;

namespace TradeManager.Domain.Models
{
    public class EventStore
    {
        public Guid Id { get; set; }

        public DateTime EnqueueDate { get; set; }

        public string Type { get; set; }

        public string Data { get; set; }

        public DateTime? ProcessedDate { get; set; }
    }
}
