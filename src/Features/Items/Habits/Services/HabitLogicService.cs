using HabitumAPI.Exceptions;
using HabitumAPI.Features.Items.Habits.Interfaces;
using HabitumAPI.Features.Users.Interfaces;
using HabitumAPI.Features.Users.Services;
using HabitumAPI.Models;

namespace HabitumAPI.Features.Items.Habits.Services;

public class HabitLogicService(IHabitRepository habitRepository, IUserLogicService userLogicService, IUserRepository userRepository) : IHabitLogicService
{
    private readonly IHabitRepository _habitRepository = habitRepository;
    private readonly IUserLogicService _userLogicService = userLogicService;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task SetDone(int id, int userId)
    {
        var habit = await _habitRepository.GetByIdAsync(id) ?? throw new NotFoundException();

        if (habit.UserId != userId)
            throw new UnauthorizedException("Não é possível marcar um hábito de outro usuário como feito.");

        var user = await _userRepository.GetByIdAsync(userId);

        var today = UserLogicService.GetUserTodayDateTime(user!.TimeZone);

        if (habit.Status != HabitStatus.Pending || habit.NextDayToBeDone != today)
            throw new BadRequestException("Não é possível concluir um hábito que não está pendente ou marcado para ser concluído hoje.");

        habit.Status = HabitStatus.Done;
        await _habitRepository.UpdateAsync(habit);

        await SetNextDayToBeDone(id);

        await _userLogicService.TryIncreaseUserStreak(userId);
        await _userLogicService.IncreaseWeekScore(userId);
    }

    public async Task SetNextDayToBeDone(int habitId) // É chamado quando um hábito é concluído
    {
        var habit = await _habitRepository.GetByIdAsync(habitId);

        var user = await _userRepository.GetByIdAsync(habit!.UserId);

        var today = UserLogicService.GetUserTodayDateTime(user!.TimeZone);

        habit.NextDayToBeDone = habit.Frequency switch
        {
            TypeFrequency.Weekly when habit.WeekDays is { Count: > 0 } =>
                GetNextWeekDay(habit.WeekDays, today),

            TypeFrequency.Interval when habit.Interval.HasValue =>
                today.AddDays(habit.Interval.Value),

            _ => today.AddDays(1),
        };

        await _habitRepository.UpdateAsync(habit);
    }

    public async Task SetNextDayToBeDoneOnCreateHabit(Habit habit)
    {
        var user = await _userRepository.GetByIdAsync(habit.UserId);
        var now = UserLogicService.GetUserNowDateTime(user!.TimeZone);
        var today = UserLogicService.GetUserTodayDateTime(user.TimeZone);

        if (habit.Frequency == TypeFrequency.Weekly)
        {
            if (habit.WeekDays!.Contains((int)now.DayOfWeek) && now.Hour < 21) // Antes das 21h TODO: ideal é perguntar/saber se o usario ainda pode fazer hoje!
            {
                habit.NextDayToBeDone = today;
                habit.Status = HabitStatus.Pending;
            }
            else
            {
                await SetNextDayToBeDone(habit.Id);
                habit.Status = HabitStatus.Inactive;
            }
        }
        else
        {
            if (now.Hour < 21) // Antes das 21h TODO: ideal é perguntar/saber se o usario ainda pode fazer hoje!
            {
                habit.NextDayToBeDone = today;
                habit.Status = HabitStatus.Pending;
            }
            else
            {
                habit.NextDayToBeDone = today.AddDays(1);
                habit.Status = HabitStatus.Inactive;
            }
        }
        await _habitRepository.UpdateAsync(habit);
    }

    #region Utils
    private static DateTime GetNextWeekDay(List<int> weekDays, DateTime today)
    {
        DayOfWeek currentDayOfWeek = today.DayOfWeek;
        int currentDayNumber = (int)currentDayOfWeek; // 0=Dom, 1=Seg, ..., 6=Sáb

        // Ordena os dias da semana fornecidos
        List<int> sortedWeekDays = [.. weekDays.OrderBy(d => d)];

        // Encontra o primeiro dia na lista que é maior que o dia atual
        int nextDayNumber = sortedWeekDays.FirstOrDefault(d => d > currentDayNumber);

        if (nextDayNumber != 0) // Encontrou um dia na mesma semana
        {
            int daysToAdd = nextDayNumber - currentDayNumber;
            return today.AddDays(daysToAdd);
        }
        else // Não encontrou, pega o primeiro dia da semana seguinte
        {
            int daysToAdd = (7 - currentDayNumber) + sortedWeekDays[0];
            return today.AddDays(daysToAdd);
        }
    }
    #endregion
}