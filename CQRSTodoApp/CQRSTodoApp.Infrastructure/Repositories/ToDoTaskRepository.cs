using CQRSTodoApp.Domain.Infrastructure;
using CQRSTodoApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSTodoApp.Infrastructure.Repositories
{
    public class ToDoTaskRepository : IToDoTaskRepository
    {
        private readonly Context _context;

        public ToDoTaskRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateToDoTaskAsync(TodoTask toDoTask)
        {
            await _context.TodoTasks.AddAsync(toDoTask);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteToDoTaskByIdAsync(int toDoTaskId)
        {
            var task = await _context.TodoTasks.FirstOrDefaultAsync(t => t.Id == toDoTaskId);
            if (task is null)
            {
                return false;
            }

            _context.TodoTasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<TodoTask>> GetAllToDoTasksAsync()
        {
            return await _context.TodoTasks.ToListAsync();
        }

        public Task<TodoTask?> GetToDoTaskByIdAsync(int toDoTaskId)
        {
            return _context.TodoTasks.FirstOrDefaultAsync(t => t.Id == toDoTaskId);
        }

        public async Task UpdateToDoTaskAsync(TodoTask updatedToDoTask)
        {
            _context.TodoTasks.Update(updatedToDoTask);
            await _context.SaveChangesAsync();
        }
    }
}
