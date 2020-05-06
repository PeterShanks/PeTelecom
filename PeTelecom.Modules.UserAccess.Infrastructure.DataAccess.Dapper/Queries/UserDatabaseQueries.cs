using System;
using System.Collections.Generic;
using Dapper;
using PeTelecom.Modules.UserAccess.Application.Authentication.Authenticate;
using PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.Dapper.Interfaces;
using System.Data;
using System.Threading.Tasks;
using PeTelecom.Modules.UserAccess.Application;
using PeTelecom.Modules.UserAccess.Application.Authorization.GetUserPermissions;

namespace PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.Dapper.Queries
{
    internal class UserDatabaseQueries : IUserDatabaseQueries
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public UserDatabaseQueries(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        public Task<UserDto> GetUserByLoginAsync(string login)
        {
            using (var connection = _sqlConnectionFactory.GetOpenConnection())
            {
                return connection.QueryFirstAsync<UserDto>(
                    "[User].[GetUserByLogin]",
                    new {Login = login},
                    null,
                    null,
                    CommandType.StoredProcedure);
            }
        }
        public Task<IEnumerable<UserPermissionDto>> GetUserPermissionsAsync(Guid id)
        {
            using (var connection = _sqlConnectionFactory.GetOpenConnection())
            {
                return connection.QueryAsync<UserPermissionDto>(
                    "[User].[GetUserPermissions]",
                    new { UserId = id },
                    null,
                    null,
                    CommandType.StoredProcedure);
            }
        }
    }
}
