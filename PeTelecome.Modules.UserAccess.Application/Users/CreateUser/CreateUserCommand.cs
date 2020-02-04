using PeTelecome.Modules.UserAccess.Application.Contracts;
using PeTelecome.Modules.UserAccess.Domain.UserRegistrations;

namespace PeTelecome.Modules.UserAccess.Application.Users.CreateUser
{
    public class CreateUserCommand : CommandBase
    {
        public UserRegistrationId UserRegistrationId { get; }
        internal CreateUserCommand(UserRegistrationId userRegistrationId)
        {
            UserRegistrationId = userRegistrationId;
        }
    }
}
