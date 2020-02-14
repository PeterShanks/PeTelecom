using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecom.BuildingBlocks.Infrastructure.Outbox
{
    public class OutboxMessage
    {
        public Guid Id { get; set; }
        public DateTime OccurredOn { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public DateTime? ProcessedDate { get; set; }

        public OutboxMessage(Guid id, DateTime occurredOn, string type, string data, DateTime? processedDate)
        {
            Id = id;
            OccurredOn = occurredOn;
            Type = type;
            Data = data;
            ProcessedDate = processedDate;
        }

        public OutboxMessage(DateTime occurredOn, string type, string data)
        {
            Id = Guid.NewGuid();
            OccurredOn = occurredOn;
            Type = type;
            Data = data;
        }
    }
}
