using PeTelecom.Modules.UserAccess.Application.Configuration.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PeTelecom.Modules.UserAccess.Application.Authentication.Authenticate
{
    public class AuthenticateCommandResult : ICommandHandler<AuthenticateCommand, AuthenticationResult>
    {
        public AuthenticateCommandResult()
        {
        }

        public Task<AuthenticationResult> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
