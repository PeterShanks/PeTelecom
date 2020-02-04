using PeTelecome.BuildingBlocks.Domain;
using PeTelecome.Modules.UserAccess.Domain.UserRegistrations;
using PeTelecome.Modules.UserAccess.Domain.Users.Events;
using System.Collections.Generic;

namespace PeTelecome.Modules.UserAccess.Domain.Users
{
    public class User : Entity, IAggregateRoot
    {
        public UserId Id { get; }
        public string Login { get; }
        public string Password { get; }

        public string Email { get; }

        public bool IsActive { get; }

        public string FirstName { get; }
        public string LastName { get; }
        public string Name { get; }
        public List<UserRole> Roles { get; }

        internal static User CreateFromUserRegistration(UserRegistrationId userRegistrationId, string login, string password, string email,
                     string firstName, string lastName, string name)
        {
            return new User(userRegistrationId, login, password, email, firstName, lastName, name);
        }

        private User(UserRegistrationId userRegistrationId, string login, string password, string email,
                     string firstName, string lastName, string name)
        {
            Id = new UserId(userRegistrationId.Value);
            Login = login;
            Password = password;
            Email = email;
            IsActive = true;
            FirstName = firstName;
            LastName = lastName;
            Name = name;

            Roles = new List<UserRole>
            {
                UserRole.Client
            };

            AddDomainEvent(new UserCreatedDomainEvent(Id));
        }

    }
}
