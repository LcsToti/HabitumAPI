namespace HabitumAPI.Features.Notifications.Interfaces;

public interface INotificationService
{
    Task SaveExpoToken(int userId, string token);
}
