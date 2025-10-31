using HabitumAPI.Features.Items.Habits.Dtos.Input;
using HabitumAPI.Features.Items.Habits.Dtos.Output;

namespace HabitumAPI.Features.Items.Habits.Interfaces;

public interface IHabitCrudService
{
    Task<HabitResponseDto> GetUserHabitById(int id, int userId);
    Task<List<HabitResponseDto>> GetAllUserHabits(int userId);
    Task<List<HabitResponseDto>> GetDoneHabitsByUser(int userId);
    Task<List<HabitResponseDto>> GetPendingHabitsByUser(int userId);
    Task<HabitResponseDto> CreateUserHabit(CreateHabitRequestDto dto, int userId);
    Task<HabitResponseDto> UpdateUserHabit(UpdateHabitRequestDto dto, int id, int userId);
    Task DeleteUserHabit(int id, int userId);
}