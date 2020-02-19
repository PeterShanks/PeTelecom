using MediatR;
using PeTelecom.BuildingBlocks.Application.EventBus;
using PeTelecom.Modules.UserAccess.IntegrationEvents;
using System.Threading;
using System.Threading.Tasks;

namespace PeTelecom.Modules.UserAccess.Application.UserRegistrations.RegisterNewUser
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
                notification.DomainEvent.UserId.Value,
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
