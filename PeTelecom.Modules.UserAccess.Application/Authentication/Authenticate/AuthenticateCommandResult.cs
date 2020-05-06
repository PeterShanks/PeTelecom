using System;
using System.Threading;
using System.Threading.Tasks;
using PeTelecom.BuildingBlocks.Application.Configuration.Commands;

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
