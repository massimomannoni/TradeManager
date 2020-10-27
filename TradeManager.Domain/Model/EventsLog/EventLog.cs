using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TradeManager.Domain.Models.EventsLog
{
    public class EventLog
    {
        [Key]
        public Guid Id { get; private set; }

        public string Type { get; set; }

        public DateTime? ProcessedDate { get; set; }

        private EventLog()
        {
        }

        private EventLog (string type,  DateTime processedDate)
        {
            Id = Guid.NewGuid();
            Type = type;
            ProcessedDate = processedDate;
        }

        public static EventLog Create( string type, DateTime processedDate)
        {
            return new EventLog( type, processedDate);
        }

    }
}
