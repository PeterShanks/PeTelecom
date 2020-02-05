using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecome.BuildingBlocks.Application.SeedWork
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
