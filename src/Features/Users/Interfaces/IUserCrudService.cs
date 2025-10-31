using HabitumAPI.Features.Users.Dtos;

namespace HabitumAPI.Features.Users.Interfaces;

public interface IUserCrudService
{
    Task<List<UserServiceResponse>> GetAll();
    Task<UserServiceResponse> GetById(int id);
    Task<List<UserServiceResponse>> GetTopRankedUsers();
    Task<UserServiceResponse> UpdateProfilePic(int userId, string newProfilePic);
}