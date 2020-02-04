using MediatR;
using PeTelecome.Modules.UserAccess.Application.Configuration.Commands;
using PeTelecome.Modules.UserAccess.Domain.UserRegistrations;
using PeTelecome.Modules.UserAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeTelecome.Modules.UserAccess.Application.Users.CreateUser
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRegistrationRepository _userRegistrationRepository;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRegistrationRepository userRegistrationRepository, IUserRepository userRepository)
        {
            _userRegistrationRepository = userRegistrationRepository;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userRegistration = await _userRegistrationRepository.GetByIdAsync(request.UserRegistrationId);

            var user = userRegistration.CreateUser();

            await _userRepository.AddAsync(user);

            return Unit.Value;
        }
    }
}
