using HabitumAPI.Features.UserChallenges.Interfaces;
using HabitumAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HabitumAPI.Features.UserChallenges;

public class UserChallengesRepository(HabitumContext context) : IUserChallengesRepository
{
    private readonly HabitumContext _context = context;

    public async Task<List<Challenge>> GetIncompleteChallengesAsync(int userId)
    {
        return await _context.Challenges
        .Where(c => !c.UserChallenges.Any(uc => uc.UserId == userId))
        .ToListAsync();
    }

    public async Task<UserChallenge?> GetUserChallengeByIdAsync(int userId, int challengeId)
    {
        return await _context.UserChallenges
            .Where(uc => uc.UserId == userId && uc.ChallengeId == challengeId)
            .FirstOrDefaultAsync();
    }

    public async Task AddUserChallengeAsync(UserChallenge userChallenge)
    {
        _context.UserChallenges.Add(userChallenge);

        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsUserChallengeAsync(int userId, int challengeId, DateTime startedAt)
    {
        return await _context.UserChallenges
            .AnyAsync(uc => uc.UserId == userId && uc.ChallengeId == challengeId && uc.StartedAt.Date == startedAt.Date);
    }

    public async Task<List<UserChallenge>> GetUserChallengesOfWeekAsync(int userId, DateTime currentWeek)
    {
        return await _context.UserChallenges
            .Include(uc => uc.Challenge)
            .Where(uc => uc.UserId == userId && uc.StartedAt >= currentWeek)
            .ToListAsync();
    }
    public async Task PatchUserChallengeAsync(UserChallenge userChallenge)
    {
        _context.UserChallenges.Update(userChallenge);

        await _context.SaveChangesAsync();
    }
    public async Task<int> GetCompleteUserChallengesCountAsync(int userId)
    {
        return await _context.UserChallenges.CountAsync(uc => uc.UserId == userId && uc.CompletedAt.HasValue);
    }
    public async Task DeleteAllChallengesByUserId(int userId)
    {
        await _context.UserChallenges
            .Where(uc => uc.UserId == userId)
            .ExecuteDeleteAsync();
    }
}