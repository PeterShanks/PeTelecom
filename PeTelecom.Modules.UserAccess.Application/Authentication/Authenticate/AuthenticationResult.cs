using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecom.Modules.UserAccess.Application.Authentication.Authenticate
{
    public class AuthenticationResult
    {
        public string AuthenticationError { get; }
        public bool IsAuthenticated { get; }
        public UserDto User { get; }

        public AuthenticationResult(string authenticationError)
        {
            AuthenticationError = authenticationError;
            IsAuthenticated = false;
        }

        public AuthenticationResult(UserDto user)
        {
            User = user;
            IsAuthenticated = true;
        }
    }
}
