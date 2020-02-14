using PeTelecom.BuildingBlocks.Application.SeedWork;
using PeTelecom.Modules.UserAccess.Domain.UserRegistrations.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecom.Modules.UserAccess.Application.UserRegistrations.RegisterNewUser
{
    public class NewUserRegisteredNotification : DomainEventNotificationBase<NewUserRegisteredDomainEvent>
    {
        public NewUserRegisteredNotification(NewUserRegisteredDomainEvent domainEvent) : base(domainEvent)
        {
        }
    }
}
