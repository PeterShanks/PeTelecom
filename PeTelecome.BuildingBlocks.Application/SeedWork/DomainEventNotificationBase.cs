using PeTelecome.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecome.BuildingBlocks.Application.SeedWork
{
    public class DomainEventNotificationBase<T> : IDomainEventNotification<T> where T : IDomainEvent
    {
        public T DomainEvent { get; }

        public Guid Id { get; }

        public DomainEventNotificationBase(T domainEvent)
        {
            DomainEvent = domainEvent;
            Id = Guid.NewGuid();
        }
    }
}
