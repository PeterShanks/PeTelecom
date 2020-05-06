using System;
using MediatR;

namespace PeTelecom.BuildingBlocks.Application.Configuration.Notifications
{
    public interface IDomainEventNotification<out TEventType> : IDomainEventNotification
    {
        TEventType DomainEvent { get; }
    }
    public interface IDomainEventNotification : INotification
    {
        Guid Id { get; }
    }
}
