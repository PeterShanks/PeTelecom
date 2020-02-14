using MediatR;
using PeTelecom.Modules.UserAccess.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeTelecom.Modules.UserAccess.Application.Users.CreateUser
{
    public class UserRegistrationConfirmedNotificationHandler : INotificationHandler<UserRegistrationConfirmedNotification>
    {
        private readonly ICommandScheduler _commandScheduler;

        public UserRegistrationConfirmedNotificationHandler(ICommandScheduler commandScheduler)
        {
            _commandScheduler = commandScheduler;
        }
        public async Task Handle(UserRegistrationConfirmedNotification notification, CancellationToken cancellationToken)
        {
            await _commandScheduler.EnqueueAsync(new CreateUserCommand(notification.DomainEvent.UserRegistrationId));
        }
    }
}
