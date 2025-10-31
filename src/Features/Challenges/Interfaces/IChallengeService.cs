using HabitumAPI.Features.Challenges.DTOs.Input;
using HabitumAPI.Features.Challenges.DTOs.Output;
using HabitumAPI.Models;

namespace HabitumAPI.Features.Challenges.Interfaces;

public interface IChallengeService
{
    Task<ChallengeResponseDTO> CreateChallengeAsync(CreateChallengeRequestDTO inputDto);
    Task<ChallengeResponseDTO> GetChallengeAsync(int id);
    Task<List<ChallengeResponseDTO>> GetChallengesAsync();
    Task<ChallengeResponseDTO> UpdateChallengeAsync(UpdateChallengeRequestDTO inputDto, int id);
    Task DeleteChallengeAsync(int id);
}
