using HabitumAPI.Exceptions;
using HabitumAPI.Features.Challenges.DTOs.Output;
using HabitumAPI.Features.Challenges.Interfaces;
using HabitumAPI.Features.UserChallenges.Interfaces;
using HabitumAPI.Features.Users.Interfaces;
using HabitumAPI.Models;

namespace HabitumAPI.Features.UserChallenges;

public class UserChallengesService(
    IUserChallengesRepository userChallengesRepository,
    IUserRepository userRepository,
    IChallengeRepository challengeRepository) : IUserChallengesService
{
    private readonly IUserChallengesRepository _userChallengesRepository = userChallengesRepository;
    private readonly IChallengeRepository _challengesRepository = challengeRepository;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task CompleteChallenge(int userId, int challengeId)
    {
        var userChallenge = await _userChallengesRepository.GetUserChallengeByIdAsync(userId, challengeId)
            ?? throw new NotFoundException($"Desafio não encontrado para o usuário. UserId: {userId}, ChallengeId: {challengeId}");

        var challenge = await _challengesRepository.GetByIdAsync(challengeId)
            ?? throw new NotFoundException($"Desafio não encontrado. ChallengeId: {challengeId}");

        var user = await _userRepository.GetByIdAsync(userId)
            ?? throw new NotFoundException($"Usuário não encontrado. UserId: {userId}");

        user.WeekScore += challenge.Points;

        await _userRepository.UpdateAsync(user);

        var utcToday = DateTime.UtcNow.Date;
        userChallenge.CompleteUserChallenge(utcToday);

        await _userChallengesRepository.PatchUserChallengeAsync(userChallenge);
    }

    public async Task<List<ChallengeResponseDTO>> GetWeeklyChallenges(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId) ?? throw new NotFoundException($"Usuário não encontrado. UserId: {userId}");

        var utcToday = DateTime.UtcNow.Date;
        var lastSunday = utcToday.AddDays(-(int)utcToday.DayOfWeek);

        if (user.LastChallengesReset < lastSunday)
        {
            try
            {
                var challenges = await RandomUndoneChallenges(user.Id);

                user.LastChallengesReset = lastSunday;
                await _userRepository.UpdateAsync(user);

                return challenges;
            }
            catch (NotFoundException)
            {
                throw;
            }
        }
        var userChallenges = await _userChallengesRepository.GetUserChallengesOfWeekAsync(userId, lastSunday);

        if (userChallenges == null || userChallenges.Count == 0)
        {
            throw new NotFoundException($"Nenhum desafio encontrado para a semana atual do usuário. UserId: {userId}");
        }

        return [.. userChallenges.Select(uc => new ChallengeResponseDTO{
            Id = uc.Challenge!.Id,
            Name = uc.Challenge.Name,
            Description = uc.Challenge.Description,
            Points = uc.Challenge.Points,
            IsCompleted = uc.CompletedAt != null,
            Image = uc.Challenge.Image,
        })];
    }

    public async Task<int> GetCompleteUserChallengesCount(int userId)
    {
        return await _userChallengesRepository.GetCompleteUserChallengesCountAsync(userId);
    }

    #region Utils
    public async Task<List<ChallengeResponseDTO>> RandomUndoneChallenges(int userId)
    {
        var challenges = await _userChallengesRepository.GetIncompleteChallengesAsync(userId);

        if (challenges == null || challenges.Count == 0)
        {
            throw new NotFoundException($"Nenhum desafio incompleto encontrado para o usuário. UserId: {userId}");
        }

        var random = new Random();
        var randomChallenges = challenges.OrderBy(x => random.Next()).Take(5).ToList();

        foreach (var challenge in randomChallenges)
        {
            var existsAlready = await _userChallengesRepository.ExistsUserChallengeAsync(userId, challenge.Id, DateTime.Today);
            if (existsAlready)
            {
                continue;
            }
            var userChallenge = new UserChallenge
            {
                UserId = userId,
                ChallengeId = challenge.Id,
                StartedAt = DateTime.Today
            };
            await _userChallengesRepository.AddUserChallengeAsync(userChallenge);
        }

        return [.. randomChallenges.Select(rc => new ChallengeResponseDTO{
            Id = rc.Id,
            Name = rc.Name,
            Description = rc.Description,
            Points = rc.Points,
            IsCompleted = null,
            Image = rc.Image,
        })];
    }
    #endregion
}