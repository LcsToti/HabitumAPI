using HabitumAPI.Exceptions;
using HabitumAPI.Features.Items.Habits.Dtos.Input;
using HabitumAPI.Features.Items.Habits.Dtos.Output;
using HabitumAPI.Features.Items.Habits.Interfaces;
using HabitumAPI.Features.Users.Interfaces;
using HabitumAPI.Features.Users.Services;
using HabitumAPI.Models;

namespace HabitumAPI.Features.Items.Habits.Services;

public class HabitCrudService(IHabitRepository habitRepository, IHabitLogicService habitLogicService, IUserRepository userRepository) : IHabitCrudService
{
    private readonly IHabitRepository _habitRepository = habitRepository;
    private readonly IHabitLogicService _habitLogicService = habitLogicService;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<HabitResponseDto> CreateUserHabit(CreateHabitRequestDto dto, int userId)
    {
        if (dto.Frequency == TypeFrequency.Interval && dto.Interval < 2)
            throw new BadRequestException("Intervalo deve ser maior que 1.");

        if (dto.Frequency == TypeFrequency.Weekly && (dto.WeekDays == null || dto.WeekDays.Count == 0) )
            throw new BadRequestException("Modo semanal deve ter ao menos 1 dia selecionado.");

        var user = await _userRepository.GetByIdAsync(userId);

        var now = UserLogicService.GetUserNowDateTime(user!.TimeZone);
        var today = UserLogicService.GetUserTodayDateTime(user.TimeZone);

        var newHabit = new Habit
        {
            Name = dto.Name,
            Icon = dto.Icon,
            Color = dto.Color,
            Description = dto.Description,
            Notifications = dto.Notifications,
            Frequency = dto.Frequency,
            WeekDays = dto.WeekDays,
            Interval = dto.Interval,
            AlertHour = dto.AlertHour,
            AlertHourTime = dto.AlertHourTime,
            Goal = dto.Goal,
            UserId = userId,
            NextDayToBeDone = now.Hour <= 21 ? today : today.AddDays(1),
            Status = now.Hour <= 21 ? HabitStatus.Pending : HabitStatus.Inactive
        };

        await _habitRepository.CreateAsync(newHabit);

        await _habitLogicService.SetNextDayToBeDoneOnCreateHabit(newHabit);

        return new HabitResponseDto
        {
            Name = newHabit.Name,
            Icon = newHabit.Icon,
            Color = newHabit.Color,
            Description = newHabit.Description,
            Notifications = newHabit.Notifications,
            Frequency = newHabit.Frequency,
            WeekDays = newHabit.WeekDays,
            Interval = newHabit.Interval,
            AlertHour = newHabit.AlertHour,
            AlertHourTime = newHabit.AlertHourTime,
            Goal = newHabit.Goal,
            Id = newHabit.Id,
            NextDayToBeDone = newHabit.NextDayToBeDone,
            Status = newHabit.Status
        };
    }

    public async Task<HabitResponseDto> GetUserHabitById(int id, int userId)
    {
        var habit = await _habitRepository.GetByIdAsync(id) ?? throw new NotFoundException();

        if (userId != habit.UserId)
        {
            throw new UnauthorizedAccessException();
        }

        return new HabitResponseDto
        {
            Name = habit.Name,
            Description = habit.Description,
            Icon = habit.Icon,
            Color = habit.Color,
            Notifications = habit.Notifications,
            Frequency = habit.Frequency,
            WeekDays = habit.WeekDays,
            Interval = habit.Interval,
            AlertHour = habit.AlertHour,
            AlertHourTime = habit.AlertHourTime,
            Goal = habit.Goal,
            Id = habit.Id,
            NextDayToBeDone = habit.NextDayToBeDone,
            Status = habit.Status
        };
    }

    public async Task<List<HabitResponseDto>> GetPendingHabitsByUser(int userId)
    {
        var habits = await _habitRepository.GetPendingHabitsByUserAsync(userId);

        return [.. habits.Select(h => new HabitResponseDto
        {
            Name = h.Name,
            Description = h.Description,
            Icon = h.Icon,
            Color = h.Color,
            Notifications = h.Notifications,
            Frequency = h.Frequency,
            WeekDays = h.WeekDays,
            Interval = h.Interval,
            AlertHour = h.AlertHour,
            AlertHourTime = h.AlertHourTime,
            Goal = h.Goal,
            Id = h.Id,
            NextDayToBeDone = h.NextDayToBeDone,
            Status = h.Status
        })];
    }

    public async Task<List<HabitResponseDto>> GetDoneHabitsByUser(int userId)
    {
        var habits = await _habitRepository.GetDoneHabitsByUserAsync(userId);

        return [.. habits.Select(h => new HabitResponseDto
        {
            Name = h.Name,
            Description = h.Description,
            Icon = h.Icon,
            Color = h.Color,
            Notifications = h.Notifications,
            Frequency = h.Frequency,
            WeekDays = h.WeekDays,
            Interval = h.Interval,
            AlertHour = h.AlertHour,
            AlertHourTime = h.AlertHourTime,
            Goal = h.Goal,
            Id = h.Id,
            NextDayToBeDone = h.NextDayToBeDone,
            Status = h.Status
        })];
    }

    public async Task<List<HabitResponseDto>> GetAllUserHabits(int userId)
    {
        var habits = await _habitRepository.GetAllByUserAsync(userId);

        return [.. habits.Select(h => new HabitResponseDto
        {
            Name = h.Name,
            Description = h.Description,
            Icon = h.Icon,
            Color = h.Color,
            Notifications = h.Notifications,
            Frequency = h.Frequency,
            WeekDays = h.WeekDays,
            Interval = h.Interval,
            AlertHour = h.AlertHour,
            AlertHourTime = h.AlertHourTime,
            Goal = h.Goal,
            Id = h.Id,
            NextDayToBeDone = h.NextDayToBeDone,
            Status = h.Status
        })];
    }

    public async Task<HabitResponseDto> UpdateUserHabit(UpdateHabitRequestDto dto, int id, int userId)
    {
        var habit = await _habitRepository.GetByIdAsync(id) ?? throw new NotFoundException();
        if (habit.UserId != userId)
            throw new UnauthorizedException();

        if (dto.Name != null) habit.Name = dto.Name;
        if (dto.Description != null) habit.Description = dto.Description;
        if (dto.Icon != null) habit.Icon = dto.Icon;
        if (dto.Color != null) habit.Color = dto.Color;
        if (dto.Frequency != null) habit.Frequency = dto.Frequency.Value;
        if (dto.WeekDays != null) habit.WeekDays = dto.WeekDays;
        if (dto.Interval != null) habit.Interval = dto.Interval;
        if (dto.AlertHour != null) habit.AlertHour = dto.AlertHour.Value;
        if (dto.AlertHourTime != null) habit.AlertHourTime = dto.AlertHourTime.Value;
        if (dto.Goal != null) habit.Goal = dto.Goal;
        if (dto.Notifications != null) habit.Notifications = dto.Notifications.Value;

        await _habitRepository.UpdateAsync(habit);
        // Atualiza o próximo dia a ser feito após a atualização do hábito
        await _habitLogicService.SetNextDayToBeDoneOnCreateHabit(habit);

        return new HabitResponseDto
        {
            Id = habit.Id,
            Name = habit.Name,
            Description = habit.Description,
            Icon = habit.Icon,
            Color = habit.Color,
            Notifications = habit.Notifications,
            Frequency = habit.Frequency,
            WeekDays = habit.WeekDays,
            Interval = habit.Interval,
            AlertHour = habit.AlertHour,
            AlertHourTime = habit.AlertHourTime,
            Goal = habit.Goal,
            NextDayToBeDone = habit.NextDayToBeDone,
            Status = habit.Status
        };
    }

    public async Task DeleteUserHabit(int id, int userId)
    {
        var habit = await _habitRepository.GetByIdAsync(id) ?? throw new NotFoundException();
        if (habit.UserId != userId)
        {
            throw new UnauthorizedException();
        }
        await _habitRepository.DeleteAsync(habit);
    }
}