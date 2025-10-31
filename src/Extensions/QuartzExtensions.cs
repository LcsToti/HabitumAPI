using HabitumAPI.Features.Notifications.Jobs;
using Quartz;

namespace HabitumAPI.Extensions;

public static class QuartzExtensions
{
    public static IServiceCollection AddQuartzJobs(this IServiceCollection services)
    {
        services.AddTransient<ExpoNotificationsJob>();

        services.AddQuartz(q =>
        {
            var job1 = new JobKey("ExpoNotificationsJob");
            q.AddJob<ExpoNotificationsJob>(opts => opts.WithIdentity(job1));
            q.AddTrigger(opts => opts.ForJob(job1).WithIdentity("ExpoNotificationsTrigger")
                .WithSimpleSchedule(x => x.WithIntervalInHours(1).RepeatForever()));
        });

        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

        return services;
    }
}