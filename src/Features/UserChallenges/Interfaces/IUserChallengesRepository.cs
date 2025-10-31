using HabitumAPI.Models;

namespace HabitumAPI.Features.UserChallenges.Interfaces;

public interface IUserChallengesRepository
{
    Task<List<Challenge>> GetIncompleteChallengesAsync(int userId);
    Task<UserChallenge?> GetUserChallengeByIdAsync(int userId, int challengeId);
    Task AddUserChallengeAsync(UserChallenge userChallenge);
    Task PatchUserChallengeAsync(UserChallenge userChallenge);
    Task DeleteAllChallengesByUserId(int userId);
    Task<bool> ExistsUserChallengeAsync(int userId, int challengeId, DateTime startedAt);
    Task<List<UserChallenge>> GetUserChallengesOfWeekAsync(int userId, DateTime currentWeek);
    Task<int> GetCompleteUserChallengesCountAsync(int userId);
}
