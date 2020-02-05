using MediatR;
using PeTelecome.Modules.UserAccess.Application.Configuration.Commands;
using PeTelecome.Modules.UserAccess.Application.UserRegistrations.SendUserRegistrationConfirmationEmail;
using System.Threading;
using System.Threading.Tasks;

namespace PeTelecome.Modules.UserAccess.Application.UserRegistrations.RegisterNewUser
{
    internal class NewUserRegisteredEnqueueEmailConfirmationHandler : INotificationHandler<NewUserRegisteredNotification>
    {
        private readonly ICommandScheduler _commandScheduler;

        public NewUserRegisteredEnqueueEmailConfirmationHandler(ICommandScheduler commandScheduler)
        {
            _commandScheduler = commandScheduler;
        }

        public async Task Handle(NewUserRegisteredNotification notification, CancellationToken cancellationToken)
        {
            await _commandScheduler.EnqueueAsync(new SendUserRegistrationConfirmationEmailCommand(
                notification.DomainEvent.UserRegistrationId,
                notification.DomainEvent.Email));
        }
    }
}
