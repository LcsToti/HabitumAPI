using HabitumAPI.Features.Items.Todos.Dtos.Input;
using HabitumAPI.Features.Items.Todos.Dtos.Output;

namespace HabitumAPI.Features.Items.Todos.Interfaces;

public interface ITodoCrudService
{
    Task<TodoResponseDto> GetUserTodoById(int id, int userId);
    Task<List<TodoResponseDto>> GetAllUserTodos(int userId);
    Task<TodoResponseDto> CreateUserTodo(CreateTodoRequestDto dto, int userId);
    Task<List<TodoResponseDto>> GetPendingTodosbyUser(int userId);
    Task<List<TodoResponseDto>> GetDoneTodosbyUser(int userId);
    Task<TodoResponseDto> UpdateUserTodo(UpdateTodoRequestDto dto, int id, int userId);
    Task DeleteUserTodo(int id, int userId);
}
