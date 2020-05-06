using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeTelecom.Modules.UserAccess.Application.Outbox
{
    public interface IOutboxDatabaseQueries
    {
        Task<IEnumerable<OutboxMessageDto>> GetUnprocessedMessages();
        Task<int> UpdateProcessDate(Guid messageId, DateTime processDate);
    }
}