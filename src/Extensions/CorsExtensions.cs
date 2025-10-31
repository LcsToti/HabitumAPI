namespace HabitumAPI.Extensions;
public static class CorsExtensions
{
    public static IServiceCollection AddCorsPolicies(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
                policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            options.AddPolicy("HabitumClient", policy =>
                policy.WithOrigins("nenhum").AllowAnyMethod().AllowAnyHeader());
        });

        return services;
    }
}
