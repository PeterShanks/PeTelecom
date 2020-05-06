using System;
using System.Threading.Tasks;
using Quartz;

namespace PeTelecom.Modules.UserAccess.Infrastructure.Jobs.Obsolete
{
    [Obsolete]
    internal static class SchedulerExtensions
    {
        public static async Task ScheduleJob<TJob>(this IScheduler scheduler, string scheduleTemplate = "0/15 * * ? * *")
            where TJob : IJob
        {
            var process = JobBuilder.Create<TJob>().Build();
            var trigger =
                TriggerBuilder
                    .Create()
                    .StartNow()
                    .WithCronSchedule(scheduleTemplate)
                    .Build();

            await scheduler.ScheduleJob(process, trigger);
        }
    }
}