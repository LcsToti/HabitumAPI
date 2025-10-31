using HabitumAPI.Features.Users.Interfaces;
using HabitumAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HabitumAPI.Features.Users;

public class UserRepository(HabitumContext context) : IUserRepository
{
    private readonly HabitumContext _context = context;

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users.AsNoTracking().ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User?> GetByIdIncludeItemsAsync(int id)
    {
        return await _context.Users
            .Include(u => u.Habits)
            .Include(u => u.Todos)
            .FirstOrDefaultAsync(u => u.Id == id);
    }
    public async Task<List<User>> GetTopRankedUsersAsync(int topCount)
    {
        DateTime todayUtc = DateTime.UtcNow.Date;
        int daysSinceSunday = (int)todayUtc.DayOfWeek;
        DateTime lastSunday = todayUtc.AddDays(-daysSinceSunday);

        // Se hoje é Domingo, queremos o Domingo anterior (não o atual)
        if (todayUtc.DayOfWeek == DayOfWeek.Sunday)
        {
            lastSunday = lastSunday.AddDays(-7);
        }

        return await _context.Users
            .Where(u => u.LastDataRefresh >= lastSunday)
            .OrderByDescending(u => u.WeekScore)
            .ThenBy(u => u.Rank)
            .Take(topCount)
            .ToListAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}
