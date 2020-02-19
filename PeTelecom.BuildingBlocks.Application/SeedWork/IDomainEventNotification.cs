using MediatR;
using System;

namespace PeTelecom.BuildingBlocks.Application.SeedWork
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
