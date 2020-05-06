using Quartz;

namespace PeTelecom.Modules.UserAccess.Infrastructure.Jobs
{
    internal class JobSchedule<TJob>
        where TJob : IJob
    {
        public string CronExpression { get; }

        public JobSchedule(string cronExpression)
        {
            CronExpression = cronExpression;
        }
    }
}
