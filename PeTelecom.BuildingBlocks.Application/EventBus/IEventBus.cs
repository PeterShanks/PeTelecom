using System;

namespace PeTelecom.BuildingBlocks.Application.EventBus
{
    public interface IEventBus : IDisposable
    {
        void Publish<T>(T @event) where T : IntegrationEvent;
        void Subscribe<T>(IIntegrationEventHandler<T> handler) where T : IntegrationEvent;
        void StartConsuming();
    }
}
