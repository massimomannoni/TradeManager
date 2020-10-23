using System;

namespace TradeManager.Servuce.Infrastructure.Processing.InternalCommand
{
    public class InternalCommand
    {
        public Guid Id { get; set; }

        public DateTime EnqueueDate { get; set; }

        public string Type { get; set; }

        public string Data { get; set; }

        public DateTime? ProcessedDate { get; set; }
    }
}