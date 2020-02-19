using PeTelecom.BuildingBlocks.Infrastructure.Outbox;
using System.Threading.Tasks;

namespace PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.SqlServer
{
    internal class OutboxAccessor : IOutbox
    {
        private readonly UserAccessContext _userAccessContext;

        public OutboxAccessor(UserAccessContext userAccessContext)
        {
            _userAccessContext = userAccessContext;
        }
        public Task AddAsync(OutboxMessage message)
        {
            _userAccessContext.OutboxMessages.AddAsync(message);
            return Task.CompletedTask;
        }
    }
}
