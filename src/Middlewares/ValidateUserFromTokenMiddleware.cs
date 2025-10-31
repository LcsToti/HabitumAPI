using HabitumAPI.Features.Users.Interfaces;
using System.Security.Claims;

namespace HabitumAPI.Middlewares;

public class ValidateUserFromTokenMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;
    public async Task Invoke(HttpContext context, IUserRepository userRepository)
    {
        if (context.User.Identity?.IsAuthenticated != true)
        {
            await _next(context);
            return;
        }
        var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim != null && int.TryParse(userIdClaim.Value, out var userId))
        {
            var user = await userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Usuário não existe mais.");
                return;
            }
            var userEmailClaim = context.User.FindFirst(ClaimTypes.Email);
            if(userEmailClaim == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Token inválido.");
                return;
            }
            if(user.Email != userEmailClaim.Value)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Token inválido.");
                return;
            }
        }
        await _next(context);
    }
}
