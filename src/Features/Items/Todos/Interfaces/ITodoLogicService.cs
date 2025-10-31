namespace HabitumAPI.Features.Items.Todos.Interfaces
{
    public interface ITodoLogicService
    {
        Task SetDone(int id, int userId, DateTime date);
        Task SetInactive(int id, int userId);
    }
}
