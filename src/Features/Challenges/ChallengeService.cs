using HabitumAPI.Models;
using HabitumAPI.Features.Challenges.DTOs.Input;
using HabitumAPI.Features.Challenges.DTOs.Output;
using HabitumAPI.Features.Challenges.Interfaces;
using HabitumAPI.Exceptions;

namespace HabitumAPI.Features.Challenges;

public class ChallengeService(IChallengeRepository _challengeRepository) : IChallengeService
{
    #region CRUD
    private readonly IChallengeRepository _challengeRepository = _challengeRepository;
    public async Task<ChallengeResponseDTO> CreateChallengeAsync(CreateChallengeRequestDTO inputDto)
    {
        var challenge = new Challenge(inputDto.Name, inputDto.Description, inputDto.Points, inputDto.Image);

        await _challengeRepository.CreateAsync(challenge);

        return new ChallengeResponseDTO
        {
            Id = challenge.Id,
            Name = challenge.Name,
            Description = challenge.Description,
            Points = challenge.Points,
            IsCompleted = null,
            Image = challenge.Image
        };
    }

    public async Task<ChallengeResponseDTO> GetChallengeAsync(int id)
    {
        var challenge = await _challengeRepository.GetByIdAsync(id) ?? throw new NotFoundException($"O Desafio com id {id} não foi encontrado");

        return new ChallengeResponseDTO
        {
            Id = challenge.Id,
            Name = challenge.Name,
            Description = challenge.Description,
            Points = challenge.Points,
            IsCompleted = null,
            Image = challenge.Image
        };
    }

    public async Task<List<ChallengeResponseDTO>> GetChallengesAsync()
    {
        var challenges = await _challengeRepository.GetAllAsync();

        return [.. challenges.Select(c => new ChallengeResponseDTO
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            Points = c.Points,
            IsCompleted = null,
            Image = c.Image
        })];
    }

    public async Task<ChallengeResponseDTO> UpdateChallengeAsync(UpdateChallengeRequestDTO inputDto, int id)
    {
        var challenge = await _challengeRepository.GetByIdAsync(id) ?? throw new NotFoundException($"O Desafio com id {id} não foi encontrado");

        challenge.Update(inputDto.Name, inputDto.Description, inputDto.Points, inputDto.Image);

        await _challengeRepository.UpdateAsync(challenge);

        return new ChallengeResponseDTO
        {
            Id = challenge.Id,
            Name = challenge.Name,
            Description = challenge.Description,
            Points = challenge.Points,
            IsCompleted = null,
            Image = challenge.Image
        };
    }

    public async Task DeleteChallengeAsync(int id)
    {
        var challenge = await _challengeRepository.GetByIdAsync(id) ?? throw new NotFoundException($"O Desafio com id {id} não foi encontrado");

        await _challengeRepository.DeleteAsync(challenge);
    }
    #endregion
}
