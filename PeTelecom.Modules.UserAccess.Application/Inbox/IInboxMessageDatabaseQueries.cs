using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeTelecom.Modules.UserAccess.Application.Inbox
{
    public interface IInboxMessageDatabaseQueries
    {
        Task<IEnumerable<InboxMessageDto>> GetUnprocessedMessagesAsync();
        Task<int> UpdateProcessedDateAsync(Guid messageId, DateTime processTime);
    }
}