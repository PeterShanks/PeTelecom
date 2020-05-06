using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PeTelecom.Modules.UserAccess.Application.Inbox;
using PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.Dapper.Interfaces;

namespace PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.Dapper.Queries
{
    internal class InboxMessageDatabaseQueries : IInboxMessageDatabaseQueries
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public InboxMessageDatabaseQueries(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        public Task<IEnumerable<InboxMessageDto>> GetUnprocessedMessagesAsync()
        {
            using (var connection = _sqlConnectionFactory.GetOpenConnection())
            {
                return connection.QueryAsync<InboxMessageDto>(
                    "[User].[GetUnprocessedInboxMessages]",
                    null,
                    null,
                    null,
                    CommandType.StoredProcedure);
            }
        }

        public Task<int> UpdateProcessedDateAsync(Guid messageId, DateTime processTime)
        {
            using (var connection = _sqlConnectionFactory.GetOpenConnection())
            {
                return connection.ExecuteAsync(
                    "[User].[UpdateInboxMessageProcessDate]",
                    new {Id = messageId, Date = processTime },
                    null,
                    null,
                    CommandType.StoredProcedure);
            }
            
        }
    }
}
