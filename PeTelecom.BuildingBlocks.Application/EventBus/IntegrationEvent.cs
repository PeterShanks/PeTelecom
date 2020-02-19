using MediatR;
using System;

namespace PeTelecom.BuildingBlocks.Application.EventBus
{
    public class IntegrationEvent: INotification
    {
        public Guid Id { get; }
        public DateTime OccurredOn { get; }
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.UtcNow;
        }
    }
}
