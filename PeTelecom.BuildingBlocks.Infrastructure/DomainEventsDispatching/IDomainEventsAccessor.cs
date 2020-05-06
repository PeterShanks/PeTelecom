using System;
using System.Collections.Generic;
using System.Text;
using PeTelecom.BuildingBlocks.Domain;

namespace PeTelecom.BuildingBlocks.Infrastructure.DomainEventsDispatching
{
    public interface IDomainEventsAccessor
    {
        List<IDomainEvent> GetDomainEvents();
        void ClearDomainEvents();
    }
}
