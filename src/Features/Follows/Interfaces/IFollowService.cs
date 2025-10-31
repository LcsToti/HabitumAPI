using HabitumAPI.Features.Users.Dtos;

namespace HabitumAPI.Features.Follows.Interfaces;

public interface IFollowService
{
    Task FollowUser(int userId, int followingUserId);
    Task UnfollowUser(int userId, int followingUserId);
    Task<List<UserServiceResponse>> GetUserFollowing(int userId);
    Task<List<UserServiceResponse>> GetUserFollowers(int userId);
}