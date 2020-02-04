using PeTelecome.BuildingBlocks.Domain;

namespace PeTelecome.Modules.UserAccess.Domain.UserRegistrations.Rules
{
    public class UserRegistrationCannotBeConfirmedAfterExpirationRule : IBusinessRule
    {
        private readonly UserRegistrationStatus _actualRegistrationStatus;
        internal UserRegistrationCannotBeConfirmedAfterExpirationRule(UserRegistrationStatus actualRegistrationStatus)
        {
            _actualRegistrationStatus = actualRegistrationStatus;
        }
        public string Message => "User Registration cannot be confirmed because it is expired";
        public bool IsBroken() => _actualRegistrationStatus == UserRegistrationStatus.Expired;
    }
}
