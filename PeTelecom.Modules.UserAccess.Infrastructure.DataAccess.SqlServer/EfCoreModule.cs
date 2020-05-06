using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using PeTelecom.BuildingBlocks.DependencyInjection.Contracts;
using PeTelecom.Modules.UserAccess.Domain.Users;
using PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.SqlServer.Repositories;

namespace PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.SqlServer
{
    public class EfCoreModule : IModule
    {
        private readonly string _connectionString;
        private readonly ILoggerFactory _loggerFactory;

        public EfCoreModule(string connectionString, ILoggerFactory loggerFactory)
        {
            _connectionString = connectionString;
            _loggerFactory = loggerFactory;
        }
        public void Initialize(IModuleRegistrar registrar)
        {
            registrar.Register<IUserRepository, UserRepository>(Lifetime.Scoped);
            registrar.Register(
                () =>
                {
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<UserAccessContext>();
                    // TODO: fix connection string issue
                    dbContextOptionsBuilder.UseSqlServer(_connectionString);
                    dbContextOptionsBuilder.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

                    return new UserAccessContext(dbContextOptionsBuilder.Options, _loggerFactory);
                }, Lifetime.Scoped
            );

            // TODO: do i need to register DbContext?
            //registrar.Register<DbContext, UserAccessContext>(Lifetime.Scoped);
        }
    }
}
