using HabitumAPI.Exceptions;
using HabitumAPI.Features.Users.Dtos;
using HabitumAPI.Features.Users.Interfaces;
using HabitumAPI.Models;

namespace HabitumAPI.Features.Users.Services;

public class UserCrudService(IUserRepository userRepository, IUserLogicService userLogicService) : IUserCrudService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUserLogicService _userLogicService = userLogicService;

    public async Task<UserServiceResponse> GetById(int id)
    {
        var user = await _userRepository.GetByIdAsync(id) ?? throw new NotFoundException("Usuário não encontrado.");

        var userToday = UserLogicService.GetUserTodayDateTime(user.TimeZone);

        if (user.LastDataRefresh < userToday)
            await _userLogicService.RefreshUserData(user.Id);

        user = await _userRepository.GetByIdAsync(id);

        return new UserServiceResponse
        {
            Id = user!.Id,
            Name = user.Name,
            Email = user.Email,
            ProfilePic = user.ProfilePic,
            Freezes = user.Freezes,
            Streak = user.Streak,
            LongestStreak = user.LongestStreak,
            WeekScore = user.WeekScore,
            LastWeekScore = user.LastWeekScore,
            TotalScore = user.TotalScore,
            Rank = user.Rank,
            LastRank = user.LastRank,
            LastFreezeDecrease = user.LastFreezeDecrease,
            LastStreakIncrease = user.LastStreakIncrease,
            LastRankUpdate = user.LastRankUpdate
        };
    }

    public async Task<List<UserServiceResponse>> GetAll()
    {
        List<User> usersList = await _userRepository.GetAllAsync();

        foreach (var user in usersList)
        {
            var userToday = UserLogicService.GetUserTodayDateTime(user.TimeZone);
            if (user.LastDataRefresh < userToday)
                await _userLogicService.RefreshUserData(user.Id);
        }

        usersList = await _userRepository.GetAllAsync();

        var userResponseList = usersList.Select(user => new UserServiceResponse
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            ProfilePic = user.ProfilePic,
            Freezes = user.Freezes,
            Streak = user.Streak,
            LongestStreak = user.LongestStreak,
            WeekScore = user.WeekScore,
            LastWeekScore = user.LastWeekScore,
            TotalScore = user.TotalScore,
            Rank = user.Rank,
            LastRank = user.LastRank,
            LastFreezeDecrease = user.LastFreezeDecrease,
            LastStreakIncrease = user.LastStreakIncrease,
            LastRankUpdate = user.LastRankUpdate
        }).ToList();

        return userResponseList;
    }

    public async Task<List<UserServiceResponse>> GetTopRankedUsers()
    {
        var usersList = await _userRepository.GetTopRankedUsersAsync(20);

        foreach (var user in usersList)
        {
            var userToday = UserLogicService.GetUserTodayDateTime(user.TimeZone);
            if (user.LastDataRefresh < userToday)
                await _userLogicService.RefreshUserData(user.Id);
        }

        usersList = await _userRepository.GetTopRankedUsersAsync(20);

        return [.. usersList
            .Select(user => new UserServiceResponse
            {
                Id=user.Id,
                Name = user.Name,
                Email = user.Email,
                ProfilePic = user.ProfilePic,
                Freezes = user.Freezes,
                Streak = user.Streak,
                LongestStreak = user.LongestStreak,
                WeekScore = user.WeekScore,
                LastWeekScore = user.LastWeekScore,
                TotalScore = user.TotalScore,
                Rank = user.Rank,
                LastRank = user.LastRank,
                LastFreezeDecrease = user.LastFreezeDecrease,
                LastStreakIncrease= user.LastStreakIncrease,
                LastRankUpdate = user.LastRankUpdate
            })];
    }

    public async Task<UserServiceResponse> UpdateProfilePic(int userId, string newProfilePic)
    {
        var user = await _userRepository.GetByIdAsync(userId) ?? throw new NotFoundException("Usuário não encontrado.");
        user.ProfilePic = newProfilePic;
        await _userRepository.UpdateAsync(user);
        return new UserServiceResponse
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            ProfilePic = user.ProfilePic,
            Freezes = user.Freezes,
            Streak = user.Streak,
            LongestStreak = user.LongestStreak,
            WeekScore = user.WeekScore,
            LastWeekScore = user.LastWeekScore,
            TotalScore = user.TotalScore,
            Rank = user.Rank,
            LastRank = user.LastRank,
            LastFreezeDecrease = user.LastFreezeDecrease,
            LastStreakIncrease = user.LastStreakIncrease,
            LastRankUpdate = user.LastRankUpdate
        };
    }
}