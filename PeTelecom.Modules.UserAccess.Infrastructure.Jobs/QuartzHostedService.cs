using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Logging;
using Quartz.Spi;
using Serilog;

namespace PeTelecom.Modules.UserAccess.Infrastructure.Jobs
{
    internal class QuartzHostedService : IHostedService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IJobFactory _jobFactory;
        private readonly IEnumerable<JobSchedule<IJob>> _jobSchedules;
        private readonly ILogger _logger;
        private readonly ILogProvider _logProvider;
        public IScheduler Scheduler { get; private set; }

        public QuartzHostedService(ISchedulerFactory schedulerFactory, 
            IJobFactory jobFactory, 
            IEnumerable<JobSchedule<IJob>> jobSchedules,
            ILogger logger,
            ILogProvider logProvider)
        {
            _schedulerFactory = schedulerFactory;
            _jobFactory = jobFactory;
            _jobSchedules = jobSchedules;
            _logger = logger;
            _logProvider = logProvider;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.Information("Quartz starting...");

            LogProvider.SetCurrentLogProvider(_logProvider);
            Scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
            Scheduler.JobFactory = _jobFactory;

            foreach (var jobSchedule in _jobSchedules)
            {
                var job = jobSchedule.CreateJob();
                var trigger = jobSchedule.CreateTrigger();

                await Scheduler.ScheduleJob(job, trigger, cancellationToken);
            }

            _logger.Information("Quartz started.");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Scheduler.Shutdown(cancellationToken);
        }
    }
}
