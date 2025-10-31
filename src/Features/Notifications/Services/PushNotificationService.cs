using HabitumAPI.Features.Notifications.Interfaces;
using System.Text;

namespace HabitumAPI.Features.Notifications.Services;

public class PushNotificationService : IPushNotificationService
{
    public async Task SendNotificationManualAsync(string expoToken, string message, string textTitle)
    {
        var httpClient = new HttpClient();
        var data = new
        {
            to = expoToken,
            sound = "default",
            title = textTitle,
            body = message,
            priority = "high",
        };

        var content = new StringContent(
            System.Text.Json.JsonSerializer.Serialize(data),
            Encoding.UTF8,
            "application/json"
        );

        var response = await httpClient.PostAsync("https://exp.host/--/api/v2/push/send?useFcmV1=true", content);
        var responseString = await response.Content.ReadAsStringAsync();

        Console.WriteLine(responseString);
    }
}