namespace HabitumAPI.Features.Notifications.Interfaces;

public interface IPushNotificationService
{
    Task SendNotificationManualAsync(string expoToken, string message, string textTitle);
}
