using PeTelecom.BuildingBlocks.Application.EventBus;
using System;

namespace PeTelecom.Modules.UserAccess.IntegrationEvents
{
    public class NewUserRegisteredIntegrationEvent : IntegrationEvent
    {
        public Guid DomainEventId { get; }
        public Guid UserId { get; }
        public string Login { get; }
        public string Email { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Name { get; }
        public NewUserRegisteredIntegrationEvent(
            Guid domainEventId,
            Guid userId,
            string login,
            string email,
            string firstName,
            string lastName,
            string name)
        {
            DomainEventId = domainEventId;
            UserId = userId;
            Login = login;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Name = name;
        }
    }
}
