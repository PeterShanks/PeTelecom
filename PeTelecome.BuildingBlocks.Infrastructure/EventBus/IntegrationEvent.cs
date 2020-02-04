﻿using MediatR;
using System;

namespace PeTelecome.BuildingBlocks.Infrastructure.EventBus
{
    public abstract class IntegrationEvent: INotification
    {
        public Guid Id { get;  }
        public DateTime OccurredOn { get; }

        protected IntegrationEvent(Guid id, DateTime occurredOn)
        {
            Id = id;
            OccurredOn = occurredOn;
        }
    }
}
