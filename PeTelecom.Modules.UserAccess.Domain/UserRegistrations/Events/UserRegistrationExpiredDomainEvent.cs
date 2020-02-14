using PeTelecom.BuildingBlocks.Domain;

namespace PeTelecom.Modules.UserAccess.Domain.UserRegistrations.Events
{
    public class UserRegistrationExpiredDomainEvent : DomainEventBase
    {
        public UserRegistrationId Id { get; }
        public UserRegistrationExpiredDomainEvent(UserRegistrationId id)
        {
            Id = id;
        }
    }
}
