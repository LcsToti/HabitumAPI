using HabitumAPI.Exceptions;
using HabitumAPI.Features.Follows.Interfaces;
using HabitumAPI.Features.Users.Dtos;
using HabitumAPI.Features.Users.Interfaces;
using HabitumAPI.Models;

namespace HabitumAPI.Features.Follows;

public class FollowService(IFollowRepository followRepository, IUserRepository userRepository) : IFollowService
{
    private readonly IFollowRepository _followRepository = followRepository;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task FollowUser(int userId, int followingUserId)
    {
        if (userId == followingUserId)
        {
            throw new BadRequestException("Você não pode seguir a si mesmo.");
        }

        if (await _userRepository.GetByIdAsync(followingUserId) == null)
        {
            throw new NotFoundException("Usuário a ser seguido não foi encontrado.");
        }

        if (await _followRepository.GetFollowByIdsAsync(userId, followingUserId) != null)
        {
            throw new ConflictException("Você já está seguindo este usuário.");
        }

        var follow = new Follow
        {
            UserId = userId,
            FollowingUserId = followingUserId,
        };

        await _followRepository.CreateFollowAsync(follow);
    }

    public async Task UnfollowUser(int userId, int followingUserId)
    {
        if (await _userRepository.GetByIdAsync(followingUserId) == null)
        {
            throw new NotFoundException("Usuário não encontrado.");
        }
        var follow = await _followRepository.GetFollowByIdsAsync(userId, followingUserId)
            ?? throw new NotFoundException("Este usuário não está na sua lista de quem você segue.");

        await _followRepository.DeleteFollowAsync(follow);
    }

    public async Task<List<UserServiceResponse>> GetUserFollowing(int userId)
    {
        var followingUsers = await _followRepository.GetUserFollowingAsync(userId);

        return [.. followingUsers.Select(user => new UserServiceResponse
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
            LastRankUpdate = user.LastRankUpdate,
        })];
    }

    public async Task<List<UserServiceResponse>> GetUserFollowers(int userId)
    {
        var followerUsersList = await _followRepository.GetUserFollowersAsync(userId);

        return [.. followerUsersList.Select(user => new UserServiceResponse
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
            LastStreakIncrease= user.LastStreakIncrease,
            LastRankUpdate= user.LastRankUpdate,
        })];
    }
}