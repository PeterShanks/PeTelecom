using MediatR;
using PeTelecome.BuildingBlocks.Application.EventBus;
using PeTelecome.Modules.UserAccess.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeTelecome.Modules.UserAccess.Application.UserRegistrations.RegisterNewUser
{
    public class NewUserRegisteredPublishEventHandler : INotificationHandler<NewUserRegisteredNotification>
    {
        private readonly IEventBus _eventBus;

        public NewUserRegisteredPublishEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        public Task Handle(NewUserRegisteredNotification notification, CancellationToken cancellationToken)
        {
            _eventBus.Publish(new NewUserRegisteredIntegrationEvent(
                notification.Id,
                notification.DomainEvent.UserRegistrationId.Value,
                notification.DomainEvent.Login,
                notification.DomainEvent.Email,
                notification.DomainEvent.FirstName,
                notification.DomainEvent.LastName,
                notification.DomainEvent.Name
                ));

            return Task.CompletedTask;
        }
    }
}
