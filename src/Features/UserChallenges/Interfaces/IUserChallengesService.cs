using HabitumAPI.Features.Challenges.DTOs.Output;

namespace HabitumAPI.Features.UserChallenges.Interfaces;

public interface IUserChallengesService
{
    Task CompleteChallenge(int id, int challengeId);
    Task<List<ChallengeResponseDTO>> RandomUndoneChallenges(int userId);
    Task<List<ChallengeResponseDTO>> GetWeeklyChallenges(int userId);
    Task<int> GetCompleteUserChallengesCount(int userId);
}
