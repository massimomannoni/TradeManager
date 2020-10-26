using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TradeManager.Domain.Models.Jobs
{
    public class Job
    {
        [Key]
        public Guid Id { get; private set; }

        public DateTime EnqueueDate { get; set; }

        public string Type { get; set; }

        public string Data { get; set; }

        public DateTime ProcessedDate { get; set; }

        private Job()
        {
        }

        private Job(DateTime enqueueDate, string type, string data, DateTime processedDate)
        {
            Id = Guid.NewGuid();
            EnqueueDate = enqueueDate;
            Type = type;
            Data = data;
            ProcessedDate = processedDate;
        }

        public static Job Create(DateTime enqueueDate, string type, string data, DateTime processedDate)
        {
            return new Job(enqueueDate, type, data, processedDate);
        }

    }
}
