using HabitumAPI.Features.Users.Interfaces;
using System.Security.Claims;

namespace HabitumAPI.Middlewares;

public class UserDataRefreshMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context, IUserLogicService userLogicService)
    {
        if (context.User.Identity?.IsAuthenticated == true &&
            int.TryParse(context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId))
        {
            await userLogicService.RefreshUserData(userId);
        }

        await _next(context);
    }
}
