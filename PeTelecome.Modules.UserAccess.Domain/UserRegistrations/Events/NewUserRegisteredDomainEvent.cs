using PeTelecome.BuildingBlocks.Domain;
using System;

namespace PeTelecome.Modules.UserAccess.Domain.UserRegistrations.Events
{
    public class NewUserRegisteredDomainEvent: DomainEventBase
    {
        public UserRegistrationId UserRegistrationId { get; }
        public string Login { get; }
        public string Password { get; }
        public string Email { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Name { get; }
        public DateTime RegisterDate { get; }

        public NewUserRegisteredDomainEvent(
            UserRegistrationId userRegistrationId,
            string login,
            string password,
            string email,
            string firstName,
            string lastName,
            DateTime registerDate
            )
        {
            UserRegistrationId = userRegistrationId;
            Login = login;
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            RegisterDate = registerDate;
        }
    }
}
