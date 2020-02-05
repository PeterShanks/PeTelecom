using MediatR;
using PeTelecome.Modules.UserAccess.Application.Configuration.Commands;
using PeTelecome.Modules.UserAccess.Domain.UserRegistrations;
using System.Threading;
using System.Threading.Tasks;

namespace PeTelecome.Modules.UserAccess.Application.UserRegistrations.ConfirmUserRegistration
{
    public class ConfirmUserRegistrationCommandHandler : ICommandHandler<ConfirmUserRegistrationCommand>
    {
        private readonly IUserRegistrationRepository _userRegistrationRepository;

        public ConfirmUserRegistrationCommandHandler(IUserRegistrationRepository userRegistrationRepository)
        {
            _userRegistrationRepository = userRegistrationRepository;
        }

        public async Task<Unit> Handle(ConfirmUserRegistrationCommand request, CancellationToken cancellationToken)
        {
            var userRegistration = await _userRegistrationRepository.GetByIdAsync(request.UserRegistrationId);

            userRegistration.Confirm();

            return Unit.Value;
        }
    }
}
