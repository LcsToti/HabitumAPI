using HabitumAPI.Models;

namespace HabitumAPI.Features.Users.Interfaces;
public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByIdIncludeItemsAsync(int id);
    Task<List<User>> GetAllAsync();
    Task<List<User>> GetTopRankedUsersAsync(int topCount);
    Task UpdateAsync(User user);
}
