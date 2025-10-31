using HabitumAPI.Exceptions;
using HabitumAPI.Features.Notifications.Interfaces;
using HabitumAPI.Features.Users.Interfaces;

namespace HabitumAPI.Features.Notifications.Services;

public class NotificationService(IUserRepository userRepository) : INotificationService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task SaveExpoToken(int userId, string token)
    {
        var user = await _userRepository.GetByIdAsync(userId) ?? throw new NotFoundException("Usuário não encontrado.");
        user.ExpoToken = token;
        await _userRepository.UpdateAsync(user);
    }
}
