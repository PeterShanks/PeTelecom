using PeTelecome.BuildingBlocks.Domain;

namespace PeTelecome.Modules.UserAccess.Domain.UserRegistrations.Events
{
    public class UserRegistrationConfirmedDomainEvent : DomainEventBase
    {
        public UserRegistrationId UserRegistrationId { get; }

        public UserRegistrationConfirmedDomainEvent(UserRegistrationId userRegistrationId)
        {
            UserRegistrationId = userRegistrationId;
        }
    }
}
