using PeTelecome.BuildingBlocks.Domain;

namespace PeTelecome.Modules.UserAccess.Domain.UserRegistrations.Rules
{
    public class UserLoginMustBeUniqueRule : IBusinessRule
    {
        private readonly IUsersCounter _userCounter;
        private readonly string _login;

        internal UserLoginMustBeUniqueRule(IUsersCounter userCounter, string login)
        {
            _userCounter = userCounter;
            _login = login;
        }

        public string Message => "User Login must be unique";

        public bool IsBroken() => _userCounter.CountUsersWithLogin(_login) > 0;
    }
}
