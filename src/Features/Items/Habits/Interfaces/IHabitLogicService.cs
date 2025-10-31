using HabitumAPI.Models;

namespace HabitumAPI.Features.Items.Habits.Interfaces;

public interface IHabitLogicService
{
    Task SetDone(int id, int userId);
    Task SetNextDayToBeDone(int habitId);
    Task SetNextDayToBeDoneOnCreateHabit(Habit habit);
}
