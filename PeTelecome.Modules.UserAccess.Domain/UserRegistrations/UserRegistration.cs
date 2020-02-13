using PeTelecome.BuildingBlocks.Domain;
using PeTelecome.Modules.UserAccess.Domain.UserRegistrations.Events;
using PeTelecome.Modules.UserAccess.Domain.UserRegistrations.Rules;
using PeTelecome.Modules.UserAccess.Domain.Users;
using System;

namespace PeTelecome.Modules.UserAccess.Domain.UserRegistrations
{
    public class UserRegistration : Entity, IAggregateRoot
    {
        public UserRegistrationId Id { get; }
        public string Login { get; }
        public string Password { get; }
        public string Email { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Name { get; }
        public DateTime RegisterDate { get; }
        public UserRegistrationStatus Status { get; private set; }
        public DateTime? ConfirmedDate { get; private set; }

        public static UserRegistration RegisterNewUser(
            string login,
            string password,
            string email,
            string firstName,
            string lastName,
            IUsersCounter usersCounter)
        {
            return new UserRegistration(login, password, email, firstName, lastName, usersCounter);
        }

        public static UserRegistration Load(UserRegistrationId id, string login, string password, string email, string firstName,
                              string lastName, string name, DateTime registerDate, UserRegistrationStatus status,
                              DateTime? confirmedDate)
        {
            return new UserRegistration(id, login, password, email, firstName,
                              lastName, name, registerDate, status,
                              confirmedDate);
        }

        internal UserRegistration(
            string login,
            string password,
            string email,
            string firstName,
            string lastName,
            IUsersCounter usersCounter // TODO: Domain entities should not have any dependencies on them
            )
        {
            CheckRule(new UserLoginMustBeUniqueRule(usersCounter, login));

            Id = new UserRegistrationId(Guid.NewGuid());
            Login = login;
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            RegisterDate = DateTime.UtcNow;
            Status = UserRegistrationStatus.WaitingForConfirmation;

            AddDomainEvent(new NewUserRegisteredDomainEvent(Id, Login, Password, Email, FirstName, LastName, RegisterDate));
        }

        internal UserRegistration(UserRegistrationId id, string login, string password, string email, string firstName,
                              string lastName, string name, DateTime registerDate, UserRegistrationStatus status,
                              DateTime? confirmedDate)
        {
            Id = id;
            Login = login;
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Name = name;
            RegisterDate = registerDate;
            Status = status;
            ConfirmedDate = confirmedDate;
        }

        public User CreateUser()
        {
            CheckRule(new UserCannotBeCreatedWhenRegistrationIsNotConfirmedRule(Status));

            return User.CreateFromUserRegistration(Id, Login, Password, Email, FirstName, LastName, Name);
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
