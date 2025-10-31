using HabitumAPI.Features.Challenges;
using HabitumAPI.Features.Challenges.Interfaces;
using HabitumAPI.Features.Follows;
using HabitumAPI.Features.Follows.Interfaces;
using HabitumAPI.Features.Items.Habits;
using HabitumAPI.Features.Items.Habits.Interfaces;
using HabitumAPI.Features.Items.Todos;
using HabitumAPI.Features.Items.Todos.Interfaces;
using HabitumAPI.Features.Notifications.Interfaces;
using HabitumAPI.Features.Notifications.Services;
using HabitumAPI.Features.UserChallenges;
using HabitumAPI.Features.UserChallenges.Interfaces;
using HabitumAPI.Features.Users;
using HabitumAPI.Features.Users.Interfaces;

namespace HabitumAPI.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IHabitRepository, HabitRepository>();
        services.AddScoped<ITodoRepository, TodoRepository>();
        services.AddScoped<IChallengeRepository, ChallengeRepository>();
        services.AddScoped<IUserChallengesRepository, UserChallengesRepository>();
        services.AddScoped<IFollowRepository, FollowRepository>();
        services.AddScoped<INotificationService, NotificationService>();

        return services;
    }
}
