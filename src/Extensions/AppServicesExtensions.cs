using HabitumAPI.Features.Auth;
using HabitumAPI.Features.Auth.Interfaces;
using HabitumAPI.Features.Auth.Utils;
using HabitumAPI.Features.Challenges;
using HabitumAPI.Features.Challenges.Interfaces;
using HabitumAPI.Features.Follows;
using HabitumAPI.Features.Follows.Interfaces;
using HabitumAPI.Features.Items.Habits.Interfaces;
using HabitumAPI.Features.Items.Habits.Services;
using HabitumAPI.Features.Items.Todos.Interfaces;
using HabitumAPI.Features.Items.Todos.Services;
using HabitumAPI.Features.Notifications.Interfaces;
using HabitumAPI.Features.Notifications.Services;
using HabitumAPI.Features.UserChallenges;
using HabitumAPI.Features.UserChallenges.Interfaces;
using HabitumAPI.Features.Users.Interfaces;
using HabitumAPI.Features.Users.Services;

namespace HabitumAPI.Extensions;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserCrudService, UserCrudService>();
        services.AddScoped<IUserLogicService, UserLogicService>();
        services.AddScoped<IAuthServices, AuthServices>();
        services.AddScoped<ITokenGenerator, TokenGenerator>();
        services.AddScoped<IHabitCrudService, HabitCrudService>();
        services.AddScoped<IHabitLogicService, HabitLogicService>();
        services.AddScoped<ITodoCrudService, TodoCrudService>();
        services.AddScoped<IChallengeService, ChallengeService>();
        services.AddScoped<IUserChallengesService, UserChallengesService>();
        services.AddScoped<IFollowService, FollowService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IPushNotificationService, PushNotificationService>();
        services.AddScoped<ITodoLogicService, TodoLogicService>();

        return services;
    }
}