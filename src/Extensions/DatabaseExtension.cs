using HabitumAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HabitumAPI.Extensions;

public static class DatabaseExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config["ConnectionStrings:HabitumContext"];
        if (string.IsNullOrEmpty(connectionString))
            throw new Exception("Database's connection string is null or empty.");

        services.AddDbContext<HabitumContext>(options =>
            options.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString),
                mySqlOptions => mySqlOptions.EnableRetryOnFailure())
        );
        return services;
    }
}
