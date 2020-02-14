using PeTelecom.BuildingBlocks.Application.SeedWork;
using PeTelecom.Modules.UserAccess.Domain.UserRegistrations.Events;

namespace PeTelecom.Modules.UserAccess.Application.Users.CreateUser
{
    public class UserRegistrationConfirmedNotification : DomainEventNotificationBase<UserRegistrationConfirmedDomainEvent>
    {
        public UserRegistrationConfirmedNotification(UserRegistrationConfirmedDomainEvent domainEvent) : base(domainEvent)
        {
        }
    }
}
