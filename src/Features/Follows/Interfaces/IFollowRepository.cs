using HabitumAPI.Models;

namespace HabitumAPI.Features.Follows.Interfaces;

public interface IFollowRepository
{
    Task<Follow?> GetFollowByIdsAsync(int userId, int followingUserId);
    Task CreateFollowAsync(Follow follow);
    Task DeleteFollowAsync(Follow follow);
    Task<List<User>> GetUserFollowingAsync(int userId);
    Task<List<User>> GetUserFollowersAsync(int userId);
}