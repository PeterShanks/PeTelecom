using Dapper;
using PeTelecom.Modules.UserAccess.Application.Authentication.Authenticate;
using PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.Dapper.Interfaces;
using System.Data;
using System.Threading.Tasks;

namespace PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.Dapper.Queries
{
    internal class GetUserLoginDatabaseQuery : IGetUserLoginDatabaseQuery
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetUserLoginDatabaseQuery(ISqlConnectionFactory sqlConnectionFactory)
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
    }
}
