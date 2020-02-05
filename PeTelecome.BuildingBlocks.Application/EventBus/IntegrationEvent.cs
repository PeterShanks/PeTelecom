using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecome.BuildingBlocks.Application.EventBus
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
