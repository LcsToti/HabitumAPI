using HabitumAPI.Features.Items.Habits.Interfaces;
using HabitumAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HabitumAPI.Features.Items.Habits;

public class HabitRepository(HabitumContext context) : IHabitRepository
{
    private readonly HabitumContext _context = context;

    public async Task<List<Habit>> GetAllByUserAsync(int userId)
    {
        return await _context.Habits
                             .Where(h => h.UserId == userId)
                             .ToListAsync();
    }

    public async Task<List<Habit>> GetPendingHabitsByUserAsync(int userId)
    {
        return await _context.Habits.Where(h => h.UserId == userId && h.Status == HabitStatus.Pending).ToListAsync();
    }
    public async Task<List<Habit>> GetDoneHabitsByUserAsync(int userId)
    {
        return await _context.Habits.Where(h => h.UserId == userId && h.Status == HabitStatus.Done).ToListAsync();
    }

    public async Task<Habit?> GetByIdAsync(int id)
    {
        return await _context.Habits.FindAsync(id);
    }

    public async Task<Habit> CreateAsync(Habit habit)
    {
        await _context.Habits.AddAsync(habit);
        await _context.SaveChangesAsync();
        return habit;
    }

    public async Task UpdateAsync(Habit habit)
    {
        _context.Habits.Update(habit);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(Habit habit)
    {
        _context.Habits.Remove(habit);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> HasPendingHabitsAsync(int userId)
    {
        return await _context.Habits.AnyAsync(h => h.UserId == userId && h.Status == HabitStatus.Pending);
    }

    public async Task<int> GetDoneHabitsCountAsync(int userId)
    {
        return await _context.Habits.CountAsync(h => h.UserId == userId && h.Status == HabitStatus.Done);
    }
}
