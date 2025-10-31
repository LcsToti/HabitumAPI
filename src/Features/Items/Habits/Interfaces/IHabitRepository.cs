using HabitumAPI.Models;

namespace HabitumAPI.Features.Items.Habits.Interfaces;

public interface IHabitRepository
{
    Task<Habit?> GetByIdAsync(int id);
    Task<List<Habit>> GetAllByUserAsync(int userId);
    Task<List<Habit>> GetPendingHabitsByUserAsync(int userId);
    Task<List<Habit>> GetDoneHabitsByUserAsync(int userId);
    Task<Habit> CreateAsync(Habit habit);
    Task UpdateAsync(Habit habit);
    Task DeleteAsync(Habit habit);
    Task<bool> HasPendingHabitsAsync(int userId);
    Task<int> GetDoneHabitsCountAsync(int userId);
}