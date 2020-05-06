using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PeTelecom.Modules.UserAccess.Application.InternalCommands;
using PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.Dapper.Interfaces;

namespace PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.Dapper.Queries
{
    internal class InternalCommandDatabaseQueries : IInternalCommandDatabaseQueries
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public InternalCommandDatabaseQueries(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        public Task<IEnumerable<InternalCommandDto>> GetInternalCommands()
        {
            using (var connection = _sqlConnectionFactory.GetOpenConnection())
            {
                return connection.QueryAsync<InternalCommandDto>(
                    "[User].[GetUnprocessedInternalCommands]",
                    null,
                    null,
                    null,
                    CommandType.StoredProcedure);
            }
        }
    }
}
