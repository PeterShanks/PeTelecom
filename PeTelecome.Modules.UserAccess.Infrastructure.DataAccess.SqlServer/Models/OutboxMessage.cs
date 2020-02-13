using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecome.Modules.UserAccess.Infrastructure.DataAccess.SqlServer.Models
{
    public class OutboxMessage
    {
        public Guid Id { get; set; }
        public DateTime OccurredOn { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public DateTime? ProcessedDate { get; set; }
    }
}
