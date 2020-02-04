using MediatR;
using System;

namespace PeTelecome.BuildingBlocks.Domain
{
    public interface IDomainEvent: INotification
    {
        DateTime OccurredOn { get; }
    }
}
