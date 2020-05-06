using MediatR;
using PeTelecom.Modules.UserAccess.Domain.Users;
using System.Threading;
using System.Threading.Tasks;
using PeTelecom.BuildingBlocks.Application.Configuration.Commands;

namespace PeTelecom.Modules.UserAccess.Application.UserRegistrations.ConfirmUserRegistration
{
    public class ConfirmUserRegistrationCommandHandler : ICommandHandler<ConfirmUserRegistrationCommand>
    {
        private readonly IUserRepository _userRepository;

        public ConfirmUserRegistrationCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(ConfirmUserRegistrationCommand request, CancellationToken cancellationToken)
        {
            var userRegistration = await _userRepository.GetByIdAsync(request.UserId);

            userRegistration.Confirm();

            return Unit.Value;
        }
    }
}
