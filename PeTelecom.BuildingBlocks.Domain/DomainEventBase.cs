using System;

namespace PeTelecom.BuildingBlocks.Domain
{
    public class DomainEventBase : IDomainEvent
    {
        public DateTime OccurredOn { get; }

        public DomainEventBase()
        {
            OccurredOn = DateTime.UtcNow;
        }
    }
}
