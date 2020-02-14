using PeTelecom.Modules.UserAccess.Application.Configuration.Commands;
using PeTelecom.Modules.UserAccess.Application.Contracts;
using PeTelecom.Modules.UserAccess.Domain.UserRegistrations;

namespace PeTelecom.Modules.UserAccess.Application.Users.CreateUser
{
    public class CreateUserCommand : InternalCommandBase
    {
        public UserRegistrationId UserRegistrationId { get; }
        internal CreateUserCommand(UserRegistrationId userRegistrationId)
        {
            UserRegistrationId = userRegistrationId;
        }
    }
}
