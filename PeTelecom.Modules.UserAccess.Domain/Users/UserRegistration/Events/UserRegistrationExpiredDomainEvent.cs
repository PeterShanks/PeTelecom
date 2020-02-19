using PeTelecom.BuildingBlocks.Domain;

namespace PeTelecom.Modules.UserAccess.Domain.Users.UserRegistration.Events
{
    public class UserRegistrationExpiredDomainEvent : DomainEventBase
    {
        public UserId Id { get; }
        public UserRegistrationExpiredDomainEvent(UserId id)
        {
            Id = id;
        }
    }
}
