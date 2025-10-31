using HabitumAPI.Features.Items.Todos.Interfaces;
using HabitumAPI.Features.Users.Interfaces;
using HabitumAPI.Exceptions;

using HabitumAPI.Models;

namespace HabitumAPI.Features.Items.Todos.Services
{
    public class TodoLogicService(ITodoRepository todoRepository, IUserLogicService userLogicService, IUserRepository userRepository) : ITodoLogicService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IUserLogicService _userLogicService = userLogicService;
        private readonly ITodoRepository _todoRepository = todoRepository;

        public async Task SetDone(int id, int userId, DateTime date)
        {
            var todo = await _todoRepository.GetByIdAsync(id) ?? throw new NotFoundException();
            if (todo.UserId !=  userId) throw new UnauthorizedException("Não é possível marcar uma tarefa de outro usuário como feita.");

            todo.Status = ToDoStatus.done;
            todo.CompletedAt = date;
            await _todoRepository.UpdateAsync(todo);
        }

        public async Task SetInactive(int id, int userId)
        {
            var todo = await _todoRepository.GetByIdAsync(id) ?? throw new NotFoundException();
            if (todo.UserId != userId) throw new UnauthorizedException("Não é possível colocar uma tarefa de outro usuário como inativa.");

            todo.Status = ToDoStatus.inactive;
            await _todoRepository.UpdateAsync(todo);
          
        }
    }
  
}
