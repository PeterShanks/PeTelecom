using Dapper;
using PeTelecom.Modules.UserAccess.Domain.Users;
using PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.Dapper.Interfaces;
using System.Data;

namespace PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.Dapper.Queries
{
    internal class UsersCounter : IUsersCounter
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public UsersCounter(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        public int CountUsersWithLogin(string login)
        {
            using (var connection = _sqlConnectionFactory.GetOpenConnection() )
            {
                return connection.QueryFirst<int>(
                    "[User].[CountUsersWithLogin]",
                    new {Login = login},
                    null,
                    null,
                    CommandType.StoredProcedure
                );

            }
        }
    }
}
