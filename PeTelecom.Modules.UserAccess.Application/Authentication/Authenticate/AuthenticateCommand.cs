using PeTelecom.Modules.UserAccess.Application.Contracts;

namespace PeTelecom.Modules.UserAccess.Application.Authentication.Authenticate
{
    public class AuthenticateCommand : CommandBase<AuthenticationResult>
    {
        public string Login { get; }
        public string Password { get; }
        public AuthenticateCommand(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
