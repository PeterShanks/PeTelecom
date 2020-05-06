using System.Threading.Tasks;
using PeTelecom.BuildingBlocks.DependencyInjection.Contracts;
using PeTelecom.Modules.UserAccess.Application;
using PeTelecom.Modules.UserAccess.Application.Inbox;
using PeTelecom.Modules.UserAccess.Application.InternalCommands;
using PeTelecom.Modules.UserAccess.Application.Outbox;
using PeTelecom.Modules.UserAccess.Domain.Users;
using PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.Dapper.Interfaces;
using PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.Dapper.Queries;
using PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.Dapper.Services;

namespace PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.Dapper
{
    public class DapperModule : IModule
    {
        private readonly string _connectionString;

        public DapperModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Initialize(IModuleRegistrar registrar)
        {
            registrar.Register<ISqlConnectionFactory>(() => new SqlConnectionFactory(_connectionString) , Lifetime.Scoped);
            registrar.Register<IUserDatabaseQueries, UserDatabaseQueries>(Lifetime.Scoped);
            registrar.Register<IUsersCounter, UsersCounter>(Lifetime.Scoped);
            registrar.Register<IInboxMessageDatabaseQueries, InboxMessageDatabaseQueries>(Lifetime.Scoped);
            registrar.Register<IInternalCommandDatabaseQueries, InternalCommandDatabaseQueries>(Lifetime.Scoped);
            registrar.Register<IOutboxDatabaseQueries, OutboxDatabaseQueries>(Lifetime.Scoped);
        }
    }
}
