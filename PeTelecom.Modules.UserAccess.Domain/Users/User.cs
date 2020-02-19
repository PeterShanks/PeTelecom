using PeTelecom.BuildingBlocks.Domain;
using PeTelecom.Modules.UserAccess.Domain.Users.UserRegistration.Events;
using PeTelecom.Modules.UserAccess.Domain.Users.UserRegistration.Rules;
using System;
using System.Collections.Generic;

namespace PeTelecom.Modules.UserAccess.Domain.Users
{
    public class User : Entity, IAggregateRoot
    {
        private readonly List<UserRole> _roles;

        public UserId Id { get; }
        public string Login { get; }
        public string Password { get; }
        public string Email { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Name { get; }
        public DateTime RegisterDate { get; }
        public UserRegistrationStatus Status { get; private set; }
        public DateTime? ConfirmedDate { get; private set; }
        public bool IsActive { get; }
        public IReadOnlyCollection<UserRole> Roles => _roles.AsReadOnly();



        public static User RegisterNewUser(
            string login,
            string password,
            string email,
            string firstName,
            string lastName,
            IUsersCounter usersCounter)
        {
            return new User(login, password, email, firstName, lastName, usersCounter);
        }

        public static User Load(UserId id, string login, string password, string email, string firstName,
                              string lastName, string name, bool isActive, List<UserRole> roles, DateTime registerDate, UserRegistrationStatus status,
                              DateTime? confirmedDate)
        {
            return new User(id, login, password, email, firstName,
                              lastName, name, isActive, roles, registerDate, status,
                              confirmedDate);
        }

        internal User(
            string login,
            string password,
            string email,
            string firstName,
            string lastName,
            IUsersCounter usersCounter // TODO: Domain entities should not have any dependencies on them
            )
        {
            CheckRule(new UserLoginMustBeUniqueRule(usersCounter, login));

            Id = new UserId(Guid.NewGuid());
            Login = login;
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Name = $"{firstName} {lastName}";
            RegisterDate = DateTime.UtcNow;
            Status = UserRegistrationStatus.WaitingForConfirmation;
            _roles = new List<UserRole>
            {
                new UserRole(Role.Client)
            };
            IsActive = true;

            AddDomainEvent(new NewUserRegisteredDomainEvent(Id, Login, Password, Email, Name, FirstName, LastName, RegisterDate));
        }

        internal User(UserId id, string login, string password, string email, string firstName,
                              string lastName, string name, bool isActive, List<UserRole> roles, DateTime registerDate, UserRegistrationStatus status,
                              DateTime? confirmedDate)
        {
            Id = id;
            Login = login;
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Name = name;
            IsActive = isActive;
            RegisterDate = registerDate;
            Status = status;
            ConfirmedDate = confirmedDate;
            _roles = roles;
        }

        public void Confirm()
        {
            CheckRule(new UserRegistrationCannotBeConfirmedAfterExpirationRule(Status));
            CheckRule(new UserRegistrationCannotBeExpiredMoreThanOnceRule(Status));

            Status = UserRegistrationStatus.Confirmed;
            ConfirmedDate = DateTime.UtcNow;

            AddDomainEvent(new UserRegistrationConfirmedDomainEvent(Id));
        }

        public void Expire()
        {
            CheckRule(new UserRegistrationCannotBeExpiredMoreThanOnceRule(Status));

            Status = UserRegistrationStatus.Expired;

            AddDomainEvent(new UserRegistrationExpiredDomainEvent(Id));
        }
    }
}
