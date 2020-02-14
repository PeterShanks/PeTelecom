using PeTelecom.BuildingBlocks.Domain;
using PeTelecom.Modules.UserAccess.Domain.UserRegistrations;
using PeTelecom.Modules.UserAccess.Domain.Users.Events;
using System.Collections.Generic;

namespace PeTelecom.Modules.UserAccess.Domain.Users
{
    public class User : Entity, IAggregateRoot
    {
        private List<UserRole> roles;

        public UserId Id { get; }
        public string Login { get; }
        public string Password { get; }
        public string Email { get; }
        public bool IsActive { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Name { get; }
        public IReadOnlyCollection<UserRole> Roles => roles.AsReadOnly();
        public static User CreateFromUserRegistration(UserRegistrationId userRegistrationId, string login, string password, string email,
                     string firstName, string lastName, string name)
        {
            return new User(userRegistrationId, login, password, email, firstName, lastName, name);
        }

        public static User Load(UserId id, string login, string password, string email, bool isActive, string firstName, string lastName, string name, List<UserRole> userRoles)
        {
            return new User(id, login, password, email, isActive, firstName, lastName, name, userRoles);
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

            roles = new List<UserRole>
            {
                UserRole.Client
            };

            AddDomainEvent(new UserCreatedDomainEvent(Id));
        }

        private User(UserId id, string login, string password, string email, bool isActive, string firstName, string lastName, string name, List<UserRole> userRoles)
        {
            Id = id;
            Login = login;
            Password = password;
            Email = email;
            IsActive = isActive;
            FirstName = firstName;
            LastName = lastName;
            Name = name;
            roles = userRoles;
        }

    }
}
