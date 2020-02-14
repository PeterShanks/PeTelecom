using System;

namespace PeTelecom.BuildingBlocks.Infrastructure.InternalCommands
{
    public class InternalCommand
    {
        public Guid Id { get; set; }
        public DateTime OccurredOn { set; get; }
        public string Type { get; set; }
        public string Data { get; set; }
        public DateTime? ProcessedDate { get; set; }
    }
}
