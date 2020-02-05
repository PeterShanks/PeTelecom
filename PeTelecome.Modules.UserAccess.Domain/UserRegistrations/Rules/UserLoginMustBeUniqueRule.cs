using PeTelecome.BuildingBlocks.Domain;

namespace PeTelecome.Modules.UserAccess.Domain.UserRegistrations.Rules
{
    public class UserLoginMustBeUniqueRule : IBusinessRule
    {
        private readonly IUsersCounter _usersCounter;
        private readonly string _login;

        internal UserLoginMustBeUniqueRule(IUsersCounter usersCounter, string login)
        {
            _usersCounter = usersCounter;
            _login = login;
        }

        public string Message => "User Login must be unique";

        public bool IsBroken() =>
            _usersCounter.CountUsersWithLogin(_login) > 0;
    }
}
