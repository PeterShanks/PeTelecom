using PeTelecome.BuildingBlocks.Domain;

namespace PeTelecome.Modules.UserAccess.Domain.UserRegistrations.Rules
{
    public class UserRegistrationCannotBeConfirmedMoreThanOnceRule : IBusinessRule
    {
        private readonly UserRegistrationStatus _actualRegistrationStatus;
        internal UserRegistrationCannotBeConfirmedMoreThanOnceRule(UserRegistrationStatus actualRegistrationStatus)
        {
            _actualRegistrationStatus = actualRegistrationStatus;
        }

        public string Message => "User Registeration cannot be confirmed more than once";

        public bool IsBroken() => _actualRegistrationStatus == UserRegistrationStatus.Confirmed;
    }
}
