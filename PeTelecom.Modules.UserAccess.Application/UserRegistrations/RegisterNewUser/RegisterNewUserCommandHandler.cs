using MediatR;
using PeTelecom.Modules.UserAccess.Application.Authentication;
using PeTelecom.Modules.UserAccess.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PeTelecom.Modules.UserAccess.Domain.Users;

namespace PeTelecom.Modules.UserAccess.Application.UserRegistrations.RegisterNewUser
{
    public  class RegisterNewUserCommandHandler : ICommandHandler<RegisterNewUserCommand>
    {
        public RegisterNewUserCommandHandler(IUserRepository userRepository, IUsersCounter usersCounter, IPasswordManager passwordManager)
        {
            _userRepository = userRepository;
            _usersCounter = usersCounter;
            _passwordManager = passwordManager;
        }

        private readonly IUserRepository _userRepository;
        private readonly IUsersCounter _usersCounter;
        private readonly IPasswordManager _passwordManager;

        public async Task<Unit> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
        {
            var userRegistration = User.RegisterNewUser(
                request.Login,
                _passwordManager.HashPassword(request.Password),
                request.Email,
                request.FirstName,
                request.LastName,
                _usersCounter);

            await _userRepository.AddAsync(userRegistration);

            return Unit.Value;
        }
    }
}
