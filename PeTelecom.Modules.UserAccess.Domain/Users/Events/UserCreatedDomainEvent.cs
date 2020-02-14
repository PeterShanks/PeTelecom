using PeTelecom.BuildingBlocks.Domain;

namespace PeTelecom.Modules.UserAccess.Domain.Users.Events
{
    public class UserCreatedDomainEvent: DomainEventBase
    {
        public UserId Id { get;  }
        public UserCreatedDomainEvent(UserId id)
        {
            Id = id;
        }
    }
}
