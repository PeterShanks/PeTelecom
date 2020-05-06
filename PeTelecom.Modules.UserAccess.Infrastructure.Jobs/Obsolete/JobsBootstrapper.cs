using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using PeTelecom.Modules.UserAccess.Application.Inbox;
using PeTelecom.Modules.UserAccess.Application.InternalCommands;
using PeTelecom.Modules.UserAccess.Application.Outbox;
using PeTelecom.Modules.UserAccess.Infrastructure.Jobs.Quartz;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;
using Quartz.Spi;
using Serilog;

namespace PeTelecom.Modules.UserAccess.Infrastructure.Jobs.Obsolete
{
    [Obsolete]
    internal class JobsBootstrapper
    {
        private readonly IJobFactory _jobFactory;
        private readonly ILogger _logger;

        public JobsBootstrapper(IJobFactory jobFactory, ILogger logger)
        {
            _jobFactory = jobFactory;
            _logger = logger;
        }
        public async Task InitializeAsync()
        {
            _logger.Information("Quartz starting...");

            var schedulerConfiguration = new NameValueCollection
            {
                { "Quartz.Scheduler.InstanceName", "Users" }
            };

            ISchedulerFactory schedulerFactory = new StdSchedulerFactory(schedulerConfiguration);
            IScheduler scheduler = await schedulerFactory.GetScheduler();
            scheduler.JobFactory = _jobFactory;

            LogProvider.SetCurrentLogProvider(new SerilogLogProvider(_logger));

            await scheduler.Start();
            await scheduler.ScheduleJob<Job<ProcessOutboxCommand>>();
            await scheduler.ScheduleJob<Job<ProcessInboxCommand>>();
            await scheduler.ScheduleJob<Job<ProcessInternalCommandsCommand>>();

            _logger.Information("Quartz started.");
        }
    }
}
