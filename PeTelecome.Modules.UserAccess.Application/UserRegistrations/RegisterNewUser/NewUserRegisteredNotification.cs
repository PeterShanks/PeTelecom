using PeTelecome.BuildingBlocks.Application.SeedWork;
using PeTelecome.Modules.UserAccess.Domain.UserRegistrations.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecome.Modules.UserAccess.Application.UserRegistrations.RegisterNewUser
{
    public class NewUserRegisteredNotification : DomainEventNotificationBase<NewUserRegisteredDomainEvent>
    {
        public NewUserRegisteredNotification(NewUserRegisteredDomainEvent domainEvent) : base(domainEvent)
        {
        }
    }
}
