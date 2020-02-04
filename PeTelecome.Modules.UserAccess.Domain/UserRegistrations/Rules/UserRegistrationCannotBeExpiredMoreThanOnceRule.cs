using PeTelecome.BuildingBlocks.Domain;

namespace PeTelecome.Modules.UserAccess.Domain.UserRegistrations.Rules
{
    public class UserRegistrationCannotBeExpiredMoreThanOnceRule : IBusinessRule
    {
        private readonly UserRegistrationStatus _actualRegistrationStatus;
        internal UserRegistrationCannotBeExpiredMoreThanOnceRule(UserRegistrationStatus actualRegistrationStatus)
        {
            _actualRegistrationStatus = actualRegistrationStatus;
        }
        public string Message => "User Registeration cannot be expired more than once";
        public bool IsBroken() => _actualRegistrationStatus == UserRegistrationStatus.Expired;
    }
}
