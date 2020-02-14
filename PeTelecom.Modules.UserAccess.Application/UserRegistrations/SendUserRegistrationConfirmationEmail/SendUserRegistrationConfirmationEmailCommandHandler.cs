using MediatR;
using PeTelecom.BuildingBlocks.Application.Emails;
using PeTelecom.BuildingBlocks.Application.Hosting;
using PeTelecom.Modules.UserAccess.Application.Configuration.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PeTelecom.Modules.UserAccess.Application.UserRegistrations.SendUserRegistrationConfirmationEmail
{
    internal class SendUserRegistrationConfirmationEmailCommandHandler : ICommandHandler<SendUserRegistrationConfirmationEmailCommand>
    {
        private readonly IEmailSender _emailSender;
        private readonly IDomainUrlService _hostingService;

        public SendUserRegistrationConfirmationEmailCommandHandler(IEmailSender emailSender, IDomainUrlService hostingService)
        {
            _emailSender = emailSender;
            _hostingService = hostingService;
        }

        public async Task<Unit> Handle(SendUserRegistrationConfirmationEmailCommand request, CancellationToken cancellationToken)
        {
            var emailMessage = new EmailMessage(request.Email, "PeTelecom - Please confirm registration",
                "This should be link to confirmation page. For now, please execute HTTP request " +
                $"{_hostingService.GenerateUserRegistrationConfirmationURL()}");

            await _emailSender.SendEmailAsync(emailMessage);

            return Unit.Value;
        }
    }
}
