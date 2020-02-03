using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecome.BuildingBlocks.Domain
{
    public interface IDomainEvent: INotification
    {
        DateTime OccurredOn { get; }
    }
}
