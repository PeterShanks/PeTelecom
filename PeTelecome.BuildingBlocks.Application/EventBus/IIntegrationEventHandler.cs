using System.Threading.Tasks;

namespace PeTelecome.BuildingBlocks.Application.EventBus
{
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
    {
        Task Handle(TIntegrationEvent @event);
    } 
    public interface IIntegrationEventHandler
    {
    }
}
