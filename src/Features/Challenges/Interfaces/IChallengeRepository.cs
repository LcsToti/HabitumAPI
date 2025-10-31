using HabitumAPI.Models;

namespace HabitumAPI.Features.Challenges.Interfaces;

public interface IChallengeRepository
{
    Task CreateAsync(Challenge challenge);
    Task<Challenge?> GetByIdAsync(int id);
    Task<List<Challenge>> GetAllAsync();
    Task UpdateAsync(Challenge challenge);
    Task DeleteAsync(Challenge challenge);
}
