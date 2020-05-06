using PeTelecom.Modules.UserAccess.Application.Outbox;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.Dapper.Interfaces;

namespace PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.Dapper.Queries
{
    internal class OutboxDatabaseQueries : IOutboxDatabaseQueries
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public OutboxDatabaseQueries(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        public Task<IEnumerable<OutboxMessageDto>> GetUnprocessedMessages()
        {
            using (var connection = _sqlConnectionFactory.GetOpenConnection())
            {
                return connection.QueryAsync<OutboxMessageDto>(
                    "[User].[GetUnprocessedOutboxMessages]",
                    null,
                    null,
                    null,
                    CommandType.StoredProcedure);
            }
        }

        public Task<int> UpdateProcessDate(Guid messageId, DateTime processDate)
        {
            using (var connection = _sqlConnectionFactory.GetOpenConnection())
            {
                return connection.ExecuteAsync(
                    "[User].[UpdateOutboxMessageProcessDate]", 
                    new {Id = messageId, ProcessDate = processDate },
                    null,
                    null,
                    CommandType.StoredProcedure);
            }
        }
    }
}
