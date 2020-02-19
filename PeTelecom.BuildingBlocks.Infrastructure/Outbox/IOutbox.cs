using System.Threading.Tasks;

namespace PeTelecom.BuildingBlocks.Infrastructure.Outbox
{
    public interface IOutbox
    {
        Task AddAsync(OutboxMessage message);
    }
}
