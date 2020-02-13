﻿using MediatR;
using PeTelecome.Modules.UserAccess.Application.Authentication;
using PeTelecome.Modules.UserAccess.Application.Configuration.Commands;
using PeTelecome.Modules.UserAccess.Domain.UserRegistrations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeTelecome.Modules.UserAccess.Application.UserRegistrations.RegisterNewUser
{
    public  class RegisterNewUserCommandHandler : ICommandHandler<RegisterNewUserCommand>
    {
        public RegisterNewUserCommandHandler(IUserRegistrationRepository userRegistrationRepository, IUsersCounter usersCounter, IPasswordManager passwordManager)
        {
            _userRegistrationRepository = userRegistrationRepository;
            _usersCounter = usersCounter;
            _passwordManager = passwordManager;
        }

        private readonly IUserRegistrationRepository _userRegistrationRepository;
        private readonly IUsersCounter _usersCounter;
        private readonly IPasswordManager _passwordManager;

        public async Task<Unit> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
        {
            var userRegistration = UserRegistration.RegisterNewUser(
                request.Login,
                _passwordManager.HashPassword(request.Password),
                request.Email,
                request.FirstName,
                request.LastName,
                _usersCounter);

            await _userRegistrationRepository.AddAsync(userRegistration);

            return Unit.Value;
        }
    }
}
