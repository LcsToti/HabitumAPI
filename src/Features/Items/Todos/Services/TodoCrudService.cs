using HabitumAPI.Exceptions;
using HabitumAPI.Features.Items.Todos.Dtos.Input;
using HabitumAPI.Features.Items.Todos.Dtos.Output;
using HabitumAPI.Features.Items.Todos.Interfaces;
using HabitumAPI.Features.Users.Interfaces;
using HabitumAPI.Features.Users.Services;
using HabitumAPI.Models;

namespace HabitumAPI.Features.Items.Todos.Services;

public class TodoCrudService(ITodoRepository todoRepository, IUserRepository userRepository) : ITodoCrudService
{
    private readonly ITodoRepository _todoRepository = todoRepository;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<TodoResponseDto> CreateUserTodo(CreateTodoRequestDto dto, int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId)
                   ?? throw new NotFoundException("Usuário não encontrado");

        var newTodo = new Todo
        {
            UserId = userId,
            Name = dto.Name,
            Icon = dto.Icon,
            Color = dto.Color,
            Description = dto.Description,
            Notifications = dto.Notifications,
            Date = dto.Date,
            Status = dto.Date.Date == DateTime.Today ?  ToDoStatus.pending : ToDoStatus.inactive
        };

        await _todoRepository.CreateAsync(newTodo);

        return new TodoResponseDto
        {
            Id = newTodo.Id,
            Name = newTodo.Name,
            Icon = newTodo.Icon,
            Color = newTodo.Color,
            Description = newTodo.Description,
            Notifications = newTodo.Notifications,
            Date = newTodo.Date,
            Status = newTodo.Status
        };
    }

    public async Task<TodoResponseDto> GetUserTodoById(int id, int userId)
    {
        var todo = await _todoRepository.GetByIdAsync(id) ?? throw new NotFoundException("Tarefa não encontrada");

        if (userId != todo.UserId)
        {
            throw new UnauthorizedException("Você não pode acessar tarefas de outro usuário");
        }

        return new TodoResponseDto
        {
            Id = todo.Id,
            Name = todo.Name,
            Icon = todo.Icon,
            Color = todo.Color,
            Description = todo.Description,
            Notifications = todo.Notifications,
            Date = todo.Date,
        };
    }

    public async Task<List<TodoResponseDto>> GetPendingTodosbyUser(int userId)
    {
        var todos = await _todoRepository.GetPendingTodosByUserAsync(userId);

        return [.. todos.Select(t => new TodoResponseDto {
            Id = t.Id,
            Name = t.Name,
            Icon = t.Icon,
            Color = t.Color,
            Description = t.Description,
            Notifications = t.Notifications,
            Date = t.Date,
            Status = t.Status,
            CompletedAt = t.CompletedAt

        })];
    }

    public async Task<List<TodoResponseDto>> GetDoneTodosbyUser(int userId)
    {
        var todos = await _todoRepository.GetDoneTodosByUserAsync(userId);

        return [.. todos.Select(t => new TodoResponseDto {
            Id = t.Id,
            Name = t.Name,
            Icon = t.Icon,
            Color = t.Color,
            Description = t.Description,
            Notifications = t.Notifications,
            Date = t.Date,
            Status = t.Status,
            CompletedAt = t.CompletedAt
        })];
    }


    public async Task<List<TodoResponseDto>> GetAllUserTodos(int userId)
    {
        var todos = await _todoRepository.GetAllByUserAsync(userId);

        var todosList = todos.Select(t => new TodoResponseDto
        {
            Id = t.Id,
            Name = t.Name,
            Icon = t.Icon,
            Color = t.Color,
            Description = t.Description,
            Notifications = t.Notifications,
            Date = t.Date,
        }).ToList();

        return todosList;
    }

    public async Task<TodoResponseDto> UpdateUserTodo(UpdateTodoRequestDto dto, int id, int userId)
    {
        var todo = await _todoRepository.GetByIdAsync(id) ?? throw new NotFoundException("Tarefa não encontrada");

        if (userId != todo.UserId)
        {
            throw new UnauthorizedException("Você não pode acessar tarefas de outro usuário");
        }

        if (dto.Name != null) todo.Name = dto.Name;
        if (dto.Icon != null) todo.Icon = dto.Icon;
        if (dto.Color != null) todo.Color = dto.Color;
        if (dto.Description != null) todo.Description = dto.Description;
        if (dto.Notifications != null) todo.Notifications = dto.Notifications.Value;
        todo.Date = dto.Date;
      
    
        await _todoRepository.UpdateAsync(todo);

        return new TodoResponseDto
        {
            Id = todo.Id,
            Name = todo.Name,
            Icon = todo.Icon,
            Color = todo.Color,
            Description = todo.Description,
            Notifications = todo.Notifications,
            Date = todo.Date,
        
        };
    }

    public async Task DeleteUserTodo(int id, int userId)
    {
        var todo = await _todoRepository.GetByIdAsync(id) ?? throw new NotFoundException("Tarefa não encontrada");

        if (todo.UserId != userId)
        {
            throw new UnauthorizedException("Você não pode deletar tarefas de outro usuário");
        }
        await _todoRepository.DeleteAsync(todo);
    }
}
