using PeTelecome.BuildingBlocks.Application.SeedWork;
using PeTelecome.Modules.UserAccess.Domain.UserRegistrations.Events;

namespace PeTelecome.Modules.UserAccess.Application.Users.CreateUser
{
    public class UserRegistrationConfirmedNotification : DomainEventNotificationBase<UserRegistrationConfirmedDomainEvent>
    {
        public UserRegistrationConfirmedNotification(UserRegistrationConfirmedDomainEvent domainEvent) : base(domainEvent)
        {
        }
    }
}
