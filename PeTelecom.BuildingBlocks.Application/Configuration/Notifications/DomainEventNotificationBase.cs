using System;
using PeTelecom.BuildingBlocks.Domain;

namespace PeTelecom.BuildingBlocks.Application.Configuration.Notifications
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
