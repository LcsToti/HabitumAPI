using HabitumAPI.Features.Items.Habits;
using HabitumAPI.Features.Items.Habits.Interfaces;
using HabitumAPI.Features.Notifications.Interfaces;
using HabitumAPI.Features.Users.Interfaces;
using HabitumAPI.Models;
using Quartz;
using TimeZoneConverter;

namespace HabitumAPI.Features.Notifications.Jobs;

public class ExpoNotificationsJob(IUserRepository userRepository, IHabitRepository habitRepository, IPushNotificationService pushNotificationService) : IJob
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IHabitRepository _habitRepository = habitRepository;
    private readonly IPushNotificationService _pushNotificationService = pushNotificationService;

    public async Task Execute(IJobExecutionContext context) // Podemos customizar de acordo, fiz apenas funcionar as notificações e estão funcionando quando roda em uma build
    {
        var users = await _userRepository.GetAllAsync();

        foreach (var user in users)
        {
            if (string.IsNullOrEmpty(user.ExpoToken))
            {
                continue;
            }

            var pendingHabits = await _habitRepository.GetPendingHabitsByUserAsync(user.Id);
            var tz = TZConvert.GetTimeZoneInfo(user.TimeZone);
            var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz).TimeOfDay;

            if (pendingHabits.Count != 0)
            {
                Console.WriteLine("temos habitos pendentes, enviando notificacao");
                await _pushNotificationService.SendNotificationManualAsync(user.ExpoToken, "Você tem hábitos pendentes para hoje!", "Não perca sua rotina!");
            }

            foreach (var h in pendingHabits)
            {
                if (h.AlertHour && h.AlertHourTime.HasValue)
                {
                    var habitTime = TimeZoneInfo.ConvertTimeFromUtc((DateTime)h.AlertHourTime, tz).TimeOfDay;

                    if (habitTime.Hours == now.Hours)
                    {
                        Console.WriteLine($"[MATCH HORA] Agora são {now.Hours}h, hábito marcado pra {habitTime.Hours}h");
                        await _pushNotificationService.SendNotificationManualAsync(
                            user.ExpoToken,
                            $"Sua meta é {h.Goal}",
                            $"Você precisa {h.Name} agora!"
                        );
                    }
                }
            }
        }
    }
}