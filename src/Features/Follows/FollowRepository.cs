using HabitumAPI.Features.Follows.Interfaces;
using HabitumAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HabitumAPI.Features.Follows;

public class FollowRepository(HabitumContext context) : IFollowRepository
{
    private readonly HabitumContext _context = context;

    public async Task<Follow?> GetFollowByIdsAsync(int userId, int followingUserId)
    {
        return await _context.Follows
            .FirstOrDefaultAsync(f => f.UserId == userId && f.FollowingUserId == followingUserId);
    }

    public async Task CreateFollowAsync(Follow follow)
    {
        _context.Follows.Add(follow);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteFollowAsync(Follow follow)
    {
        _context.Follows.Remove(follow);
        await _context.SaveChangesAsync();
    }
    public async Task<List<User>> GetUserFollowingAsync(int userId)
    {
        return await _context.Follows
            .Where(f => f.UserId == userId)
            .Select(f => f.FollowingUser)
            .ToListAsync();
    }

    public async Task<List<User>> GetUserFollowersAsync(int userId)
    {
        return await _context.Follows
            .Where(f => f.FollowingUserId == userId)
            .Select(f => f.User)
            .ToListAsync();
    }
}