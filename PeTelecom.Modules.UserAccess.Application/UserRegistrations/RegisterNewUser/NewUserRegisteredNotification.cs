using PeTelecom.BuildingBlocks.Application.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using PeTelecom.Modules.UserAccess.Domain.Users.UserRegistration.Events;

namespace PeTelecom.Modules.UserAccess.Application.UserRegistrations.RegisterNewUser
{
    public class NewUserRegisteredNotification : DomainEventNotificationBase<NewUserRegisteredDomainEvent>
    {
        public NewUserRegisteredNotification(NewUserRegisteredDomainEvent domainEvent) : base(domainEvent)
        {
        }
    }
}
