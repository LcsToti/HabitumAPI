using HabitumAPI.Features.Auth.Dtos;

namespace HabitumAPI.Features.Auth.Interfaces;

public interface IAuthServices
{
    Task<string> Register(RegisterRequestDTO dto);
    Task<string> Login(LoginRequestDto dto);
}