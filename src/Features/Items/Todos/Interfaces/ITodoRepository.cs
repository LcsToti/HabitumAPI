using HabitumAPI.Models;

namespace HabitumAPI.Features.Items.Todos.Interfaces;

public interface ITodoRepository
{

    Task<Todo?> GetByIdAsync(int id);
    Task<List<Todo>> GetAllByUserAsync(int userId);
    Task<List<Todo>> GetPendingTodosByUserAsync(int userId);
    Task<List<Todo>> GetDoneTodosByUserAsync(int userId);
    Task<Todo> CreateAsync(Todo todo);
    Task UpdateAsync(Todo todo);
    Task DeleteAsync(Todo todo);
}
