using PeTelecome.BuildingBlocks.Domain;

namespace PeTelecome.Modules.UserAccess.Domain.UserRegistrations.Events
{
    public class UserRegistrationConfirmedDomainEvent : DomainEventBase
    {
        public UserRegistrationId Id { get; }

        public UserRegistrationConfirmedDomainEvent(UserRegistrationId id)
        {
            Id = id;
        }
    }
}
