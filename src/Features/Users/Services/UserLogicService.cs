using HabitumAPI.Exceptions;
using HabitumAPI.Features.UserChallenges.Interfaces;
using HabitumAPI.Features.Users.Interfaces;
using HabitumAPI.Models;
using TimeZoneConverter;

namespace HabitumAPI.Features.Users.Services;

public class UserLogicService(
    IUserRepository userRepository, 
    IUserChallengesRepository userChallengesRepository, 
    ILogger<UserLogicService> logger) : IUserLogicService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUserChallengesRepository _userChallengesRepository = userChallengesRepository;
    private readonly ILogger<UserLogicService> _logger = logger;

    #region EventDrivenLogic
    public async Task TryIncreaseUserStreak(int id) // Deve ser chamada quando o usuário completa um hábito.
    {
        var user = await _userRepository.GetByIdIncludeItemsAsync(id) ?? throw new NotFoundException("Usuário não encontrado.");
        var today = GetUserTodayDateTime(user.TimeZone);
        var hasPendingHabits = user.Habits.Where(h => h.NextDayToBeDone == today).Any(h => h.Status == HabitStatus.Pending);

        if (user.LastStreakIncrease >= today || hasPendingHabits)
            return;

        user.Streak++;
        user.LastStreakIncrease = today;
        user.WeekScore += GetStreakScoreBonus(user.Streak);

        if (user.Streak > user.LongestStreak)
        {
            user.LongestStreak = user.Streak;
        }

        await _userRepository.UpdateAsync(user);

    }
    public async Task IncreaseWeekScore(int id) // Deve ser chamada quando o usuário completa um hábito.
    {
        var user = await _userRepository.GetByIdIncludeItemsAsync(id) ?? throw new NotFoundException($"Usuário não encontrado. Id: {id}");

        var doneHabitsCount = user.Habits.Count(h => h.Status == HabitStatus.Done);

        int baseWeekScore;
        double percentage;

        switch (doneHabitsCount)
        {
            case 1: baseWeekScore = 50; percentage = 0.05; break;
            case 2: baseWeekScore = 100; percentage = 0.10; break;
            default: baseWeekScore = 150; percentage = 0.15; break; // 3 ou mais hábitos concluídos
        }
        int pointsToAdd = GetPointsToAdd(user.Streak, baseWeekScore, percentage);
        user.WeekScore += pointsToAdd;
        await _userRepository.UpdateAsync(user);
    }
    #endregion

    #region DailyRefresh
    public async Task RefreshUserData(int id) // Roda uma vez por dia, é chamada pelo middleware ou por Get de outro usuario se user.LastDataRefresh for menor que hoje
    {
        var user = await _userRepository.GetByIdIncludeItemsAsync(id) ?? throw new NotFoundException($"Usuário não encontrado. Id: {id}");
        var today = GetUserTodayDateTime(user.TimeZone);
        if (user.LastDataRefresh == today)
        {
            _logger.LogInformation("Dados do usuário {UserId} já foram atualizados hoje.", user.Id);
            return;
        }

        try
        {
            await ClearUserChallenges(user);

            await TryIncreaseFreezes(user); // Deve vir ANTES de resetar a streak
            await TryResetStreak(user); // Deve vir APOS aumentar os freezes; Também pode gastar freezes

            await TrySetHabitsNextDayToBeDone(user); // Deve vir ANTES de definir o status dos hábitos
            await SetUserItemsStatus(user); // Deve vir APOS definir o NextDayToBeDone

            user.LastDataRefresh = today;

            await _userRepository.UpdateAsync(user);
            _logger.LogInformation("Dados do usuário {UserId} atualizados com sucesso.", user.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar dados do usuário {UserId}.", user.Id);
            throw;
        }
    }
    public async Task ClearUserChallenges(User user)
    {
        var utcToday = DateTime.UtcNow.Date;
        var lastSunday = utcToday.AddDays(-(int)utcToday.DayOfWeek); // Domingo mais recente
        if(user.LastChallengesReset < lastSunday)
            await _userChallengesRepository.DeleteAllChallengesByUserId(user.Id);
    }

    public async Task TryIncreaseFreezes(User user)
    {
        var today = GetUserTodayDateTime(user.TimeZone);

        var weeksPassed = (int)(today - user.LastFreezeIncrease).TotalDays / 7;
        if (weeksPassed <= 0 || user.Freezes >= user.MaxFreezes)
            return;

        var freezesToAdd = Math.Min(weeksPassed, user.MaxFreezes - user.Freezes);

        user.Freezes += freezesToAdd;
        user.LastFreezeIncrease = user.LastFreezeIncrease.AddDays(freezesToAdd * 7);

        await _userRepository.UpdateAsync(user);
    }
    public async Task TryResetStreak(User user)
    {
        var today = GetUserTodayDateTime(user.TimeZone);

        foreach (var habit in user.Habits.Where(h => h.NextDayToBeDone < today))
        {
            if (habit.Status != HabitStatus.Done)
            {
                // Lógica de resetar o streak
                if (user.Freezes > 0)
                {
                    user.Freezes--;
                    user.LastFreezeDecrease = today;
                }
                else
                {
                    user.Streak = 0;
                    user.LastStreakReset = today;
                    break;
                }
            }
        }
        await _userRepository.UpdateAsync(user);
    }
    public async Task TryUpdateRankUtc(User user)
    {
        var utcToday = DateTime.UtcNow.Date;
        var lastSunday = utcToday.AddDays(-(int)utcToday.DayOfWeek); // Domingo mais recente

        if (user.LastRankUpdate < lastSunday)
        {
            user.LastRank = user.Rank;
            user.Rank = GetRank(user.WeekScore);
            user.LastRankUpdate = lastSunday;

            await _userRepository.UpdateAsync(user);
        }
    }
    public async Task TryResetWeekScoreUtc(User user)
    {
        var utcToday = DateTime.UtcNow.Date;
        var lastSunday = utcToday.AddDays(-(int)utcToday.DayOfWeek);

        if (user.LastWeekScoreReset < lastSunday)
        {
            user.TotalScore += user.WeekScore;
            user.LastWeekScore = user.WeekScore;
            user.WeekScore = 0;
            user.LastWeekScoreReset = lastSunday;
            await _userRepository.UpdateAsync(user);
        }
    }
    public async Task TrySetHabitsNextDayToBeDone(User user)
    {
        var now = GetUserNowDateTime(user.TimeZone);
        var today = GetUserTodayDateTime(user.TimeZone);

        foreach (var habit in user.Habits.Where(h => h.NextDayToBeDone < today))
        {
            if (now.Hour < 21) // Antes das 21h TODO: ideal é perguntar/saber se o usario ainda pode fazer hoje!
            {
                habit.NextDayToBeDone = today;
            }
            else
            {
                habit.NextDayToBeDone = today.AddDays(1);
            }
        }
        await _userRepository.UpdateAsync(user);
    }
    public async Task SetUserItemsStatus(User user)
    {
        var today = GetUserTodayDateTime(user.TimeZone);

        foreach (var habit in user.Habits)
        {
            if (habit.NextDayToBeDone == today)
            {
                habit.Status = HabitStatus.Pending;
            }
            if (habit.NextDayToBeDone > today)
            {
                habit.Status = HabitStatus.Inactive;
            }
        }

        foreach (var todo in user.Todos)
        {
            if (todo.Date == today)
            {
                todo.Status = ToDoStatus.pending;
            }
            if (todo.CompletedAt < today)
            {
                todo.Status = ToDoStatus.inactive;
            }
        }

        await _userRepository.UpdateAsync(user);
    }
    #endregion

    #region Utils
    public static DateTime GetUserTodayDateTime(string timeZoneId)
    {
        var tz = TZConvert.GetTimeZoneInfo(timeZoneId);
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);
        return now.Date;
    }
    public static DateTime GetUserNowDateTime(string timeZoneId)
    {
        var tz = TZConvert.GetTimeZoneInfo(timeZoneId);
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);
        return now;
    }

    private static int GetStreakScoreBonus(int streak) => streak switch
    {
        1 => 50,
        2 => 60,
        3 => 80,
        4 => 90,
        5 => 110,
        6 => 125,
        >= 7 and <= 13 => 150,
        >= 14 and <= 20 => 200,
        >= 21 and <= 27 => 250,
        >= 28 => 300,
        _ => 0
    };

    private static int GetRank(int weekPoints) => weekPoints switch
    {
        <= 149 => 0,
        <= 349 => 1,
        <= 699 => 2,
        <= 1199 => 3,
        _ => 4
    };

    private static int GetPointsToAdd(int Streak, int baseWeekScore, double percentage) // Deve ser chamada pela IncreaseWeekScore.
    {
        int pointsToAdd = Streak > 0
        ? baseWeekScore + (int)(Streak * percentage) // Base de Pontos + Bônus da Streak
        : baseWeekScore; // Somente Base de Pontos

        return pointsToAdd;
    }
    #endregion
}