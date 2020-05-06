using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PeTelecom.BuildingBlocks.Application;
using PeTelecom.BuildingBlocks.Infrastructure.Emails;
using PeTelecom.Modules.UserAccess.Application.Contracts;
using PeTelecom.Modules.UserAccess.Infrastructure.Configuration.Logging;
using PeTelecom.Modules.UserAccess.Infrastructure.Configuration.Processing;
using PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.Dapper;
using PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.SqlServer;
using PeTelecom.Modules.UserAccess.Infrastructure.Jobs;
using Serilog;
using Serilog.Extensions.Logging;
using System;
using System.Threading;

namespace PeTelecom.Modules.UserAccess.Infrastructure.Configuration
{
    public class UserAccessStartup
    {
        public static void Initialize(string connectionString,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger,
            EmailConfiguration emailConfiguration,
            string textEncryptionKey)
        {
            RegisteredServices(logger, connectionString);

            StartUserAccessServices(UserAccessCompositionRoot.CompositionRoot, UserAccessCompositionRoot.CompositionRoot.ServicesCancellationToken);
        }

        public static IUserAccessModule UserAccessModuleFactory() =>
            UserAccessCompositionRoot.CompositionRoot.GetService<IUserAccessModule>();

        private static void RegisteredServices(ILogger logger, string connectionString)
        {
            var compositionRoot = UserAccessCompositionRoot.CompositionRoot;
            var moduleLogger = logger.ForContext("Module", "UserAccess");

            compositionRoot.AddModule(new LoggingModule(moduleLogger));
            compositionRoot.AddModule(new EfCoreModule(connectionString, new SerilogLoggerFactory(moduleLogger, true)));
            compositionRoot.AddModule(new DapperModule(connectionString));
            compositionRoot.AddModule(new JobsModule());
            compositionRoot.AddModule(new ProcessingModule());
        }

        private static async void StartUserAccessServices(IServiceProvider serviceProvider, CancellationToken cancellationToken)
        {
            var services = serviceProvider.GetServices<IHostedService>();
            foreach (var service in services)
            {
                await service.StartAsync(cancellationToken);
            }
        }
    }
}
