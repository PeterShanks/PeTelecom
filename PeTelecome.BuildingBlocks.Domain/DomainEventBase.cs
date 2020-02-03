using System;

namespace PeTelecome.BuildingBlocks.Domain
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
