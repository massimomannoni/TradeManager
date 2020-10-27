using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TradeManager.Domain.Models.EventsLog
{
    public class EventsLog
    {
        [Key]
        public Guid Id { get; private set; }

        public string Type { get; set; }

        public DateTime? ProcessedDate { get; set; }

        private EventsLog()
        {
        }

        private EventsLog (string type,  DateTime processedDate)
        {
            Id = Guid.NewGuid();
            Type = type;
            ProcessedDate = processedDate;
        }

        public static EventsLog Create( string type, DateTime processedDate)
        {
            return new EventsLog( type, processedDate);
        }

    }
}
