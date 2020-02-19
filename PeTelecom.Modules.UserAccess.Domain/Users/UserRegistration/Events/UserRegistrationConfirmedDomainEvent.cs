using PeTelecom.BuildingBlocks.Domain;

namespace PeTelecom.Modules.UserAccess.Domain.Users.UserRegistration.Events
{
    public class UserRegistrationConfirmedDomainEvent : DomainEventBase
    {
        public UserId UserId { get; }

        public UserRegistrationConfirmedDomainEvent(UserId userId)
        {
            UserId = userId;
        }
    }
}
