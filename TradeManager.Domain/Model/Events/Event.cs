using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TradeManager.Domain.Models.Events
{
    public class Event
    {
        [Key]
        public Guid Id { get; private set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }

        public string Data { get; set; }

        private Event()
        {
            // for EF
        }

        private Event(DateTime date, string type, string data)
        {
            Id = Guid.NewGuid();
            Date = date;
            Type = type;
            Data = data;
        }

        public static Event Create(DateTime date,  string type, string data)
        {
            return new Event(date, type, data);
        }

    }
}
