using Quartz;

namespace PeTelecom.Modules.UserAccess.Infrastructure.Jobs
{
    internal static class JobScheduleExtensions
    {
        public static IJobDetail CreateJob<TJob>(this JobSchedule<TJob> schedule)
            where TJob : IJob
        {
            var jobType = typeof(TJob);
            return JobBuilder
                .Create<TJob>()
                .WithIdentity(jobType.FullName)
                .WithDescription(jobType.Name)
                .Build();
        }

        public static ITrigger CreateTrigger<TJob>(this JobSchedule<TJob> jobSchedule)
            where TJob : IJob
        {
            return TriggerBuilder
                .Create()
                .WithIdentity($"{typeof(TJob).FullName}.trigger")
                .WithCronSchedule(jobSchedule.CronExpression)
                .WithDescription(jobSchedule.CronExpression)
                .Build();
        }
    }
}