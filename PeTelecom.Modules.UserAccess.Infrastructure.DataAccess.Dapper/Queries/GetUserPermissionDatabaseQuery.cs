using PeTelecom.Modules.UserAccess.Application.Authorization.GetUserPermissions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.Dapper.Interfaces;

namespace PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.Dapper.Queries
{
    internal class GetUserPermissionDatabaseQuery: IGetUserPermissionDatabaseQuery
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetUserPermissionDatabaseQuery(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        public Task<IEnumerable<UserPermissionDto>> GetUserPermissionsAsync(Guid id)
        {
            using (var connection = _sqlConnectionFactory.GetOpenConnection())
            {
                return connection.QueryAsync<UserPermissionDto>(
                    "[User].[GetUserPermissions]",
                    new {UserId = id},
                    null,
                    null,
                    CommandType.StoredProcedure);
            }
        }
    }
}
