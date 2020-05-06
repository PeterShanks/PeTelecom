using Microsoft.Extensions.Hosting;
using PeTelecom.BuildingBlocks.DependencyInjection.Contracts;
using PeTelecom.Modules.UserAccess.Application.Inbox;
using PeTelecom.Modules.UserAccess.Application.InternalCommands;
using PeTelecom.Modules.UserAccess.Application.Outbox;
using PeTelecom.Modules.UserAccess.Infrastructure.Jobs.Quartz;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;
using Quartz.Spi;

namespace PeTelecom.Modules.UserAccess.Infrastructure.Jobs
{
    public class JobsModule : IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {
            var cronExpression = "0/15 * * ? * *";

            registrar.Register(typeof(Job<>), typeof(JobsModule).Assembly, Lifetime.Singleton);
            registrar.Register<IJobFactory, SingletonJobFactory>(Lifetime.Singleton);
            registrar.Register<ISchedulerFactory, StdSchedulerFactory>(Lifetime.Singleton);

            registrar.Register<ILogProvider, SerilogLogProvider>(Lifetime.Singleton);
            registrar.Register<IHostedService, QuartzHostedService>(Lifetime.Singleton);

            registrar.Register(() => new JobSchedule<Job<ProcessInboxCommand>>(cronExpression),
                Lifetime.Singleton);
            registrar.Register(() => new JobSchedule<Job<ProcessOutboxCommand>>(cronExpression),
                Lifetime.Singleton);
            registrar.Register(() => new JobSchedule<Job<ProcessInternalCommandsCommand>>(cronExpression),
                Lifetime.Singleton);
        }
    }
}
