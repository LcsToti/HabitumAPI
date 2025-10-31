using HabitumAPI.Features.Items.Todos.Interfaces;
using HabitumAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HabitumAPI.Features.Items.Todos
{
    public class TodoRepository(HabitumContext context) : ITodoRepository
    {
        private readonly HabitumContext _context = context;

        public async Task<List<Todo>> GetAllByUserAsync(int userId)
        {
            return await _context.Todos
                                 .Where(h => h.UserId == userId)
                                 .ToListAsync();
        }

        public async Task<Todo?> GetByIdAsync(int id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<List<Todo>> GetPendingTodosByUserAsync(int userId)
        {
            return await _context.Todos.Where(t => t.UserId == userId && t.Status == ToDoStatus.pending).ToListAsync();
        }

        public async Task<List<Todo>> GetDoneTodosByUserAsync(int userId)
        {
            return await _context.Todos.Where(t => t.UserId == userId && t.Status == ToDoStatus.done).ToListAsync();
        }

        public async Task<Todo> CreateAsync(Todo todo)
        {
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task UpdateAsync(Todo todo)
        {
            _context.Todos.Update(todo);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Todo todo)
        {
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
        }
    }
}
