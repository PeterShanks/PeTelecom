using PeTelecome.Modules.UserAccess.Application.Configuration.Commands;
using PeTelecome.Modules.UserAccess.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecome.Modules.UserAccess.Application.Authentication.Authenticate
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
