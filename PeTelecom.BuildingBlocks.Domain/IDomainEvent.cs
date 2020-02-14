using MediatR;
using System;

namespace PeTelecom.BuildingBlocks.Domain
{
    public interface IDomainEvent: INotification
    {
        DateTime OccurredOn { get; }
    }
}
