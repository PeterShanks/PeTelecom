using PeTelecom.BuildingBlocks.Domain;
using System;

namespace PeTelecom.Modules.UserAccess.Domain.Users.UserRegistration.Events
{
    public class NewUserRegisteredDomainEvent: DomainEventBase
    {
        public UserId UserId { get; }
        public string Login { get; }
        public string Password { get; }
        public string Email { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Name { get; }
        public DateTime RegisterDate { get; }

        public NewUserRegisteredDomainEvent(
            UserId userId,
            string login,
            string password,
            string email,
            string name,
            string firstName,
            string lastName,
            DateTime registerDate)
        {
            UserId = userId;
            Login = login;
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            RegisterDate = registerDate;
            Name = name;
        }
    }
}
