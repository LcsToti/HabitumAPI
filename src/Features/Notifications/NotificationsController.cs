using HabitumAPI.Exceptions;
using HabitumAPI.Features.Notifications.Interfaces;
using HabitumAPI.Features.Users.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HabitumAPI.Features.Notifications;

[ApiController]
public class NotificationsController(IUserCrudService userCrudService, INotificationService notificationService) : Controller
{
    private readonly IUserCrudService _userCrudService = userCrudService;
    private readonly INotificationService _notificationsService = notificationService;

    [Authorize]
    [HttpPost("/Me/SaveExpoToken")]
    public async Task<IActionResult> SaveExpoToken([FromBody] string expoToken)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        try
        {
            var user = await _userCrudService.GetById(userId);
            user.ExpoToken = expoToken;

            await _notificationsService.SaveExpoToken(userId, expoToken);
            return Ok("Token salvo com sucesso.");
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
