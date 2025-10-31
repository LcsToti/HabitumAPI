using HabitumAPI.Models;

namespace HabitumAPI.Features.Auth.Interfaces;

public interface ITokenGenerator
{
    string GenerateToken(User user);
}
