using PeTelecom.Modules.UserAccess.Application.Configuration.Commands;
using PeTelecom.Modules.UserAccess.Application.IdentityServer;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeTelecom.Modules.UserAccess.Application.Authentication.Authenticate
{
    public class AuthenticateCommandHandler : ICommandHandler<AuthenticateCommand, AuthenticationResult>
    {
        private readonly IGetUserLoginDatabaseQuery _authenticateQuery;
        private readonly IPasswordManager _passwordManager;

        public AuthenticateCommandHandler(IGetUserLoginDatabaseQuery authenticateQuery, IPasswordManager passwordManager)
        {
            _authenticateQuery = authenticateQuery;
            _passwordManager = passwordManager;
        }

        public async Task<AuthenticationResult> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            UserDto user = await _authenticateQuery.GetUserByLoginAsync(request.Login);

            if (user == null)
                return new AuthenticationResult("Incorrect login or password");

            if(!user.IsActive)
                return new AuthenticationResult("User is not active");

            if(!_passwordManager.VerifyPassword(user.Password, request.Password))
                return new AuthenticationResult("Incorrect login or password");

            user.Claims ??= new List<Claim>();
            // TODO: Understand why do we need to add the following in the claims
            //user.Claims.Add(new Claim(CustomClaimTypes.Name, user.Name));
            //user.Claims.Add(new Claim(CustomClaimTypes.Email, user.Email));

            return new AuthenticationResult(user);
        }
    }
}
