using MediatR;
using PeTelecome.Modules.UserAccess.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeTelecome.Modules.UserAccess.Application.Authentication.Authenticate
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
