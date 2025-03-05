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

        public async Task CreateToDoTaskAsync(ToDoTask toDoTask)
        {
            await _context.ToDoTasks.AddAsync(toDoTask);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteToDoTaskByIdAsync(int toDoTaskId)
        {
            var task = await _context.ToDoTasks.FirstOrDefaultAsync(t => t.Id == toDoTaskId);
            if (task is null)
            {
                return false;
            }

            _context.ToDoTasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ToDoTask>> GetAllToDoTasksAsync()
        {
            return await _context.ToDoTasks.ToListAsync();
        }

        public Task<ToDoTask?> GetToDoTaskByIdAsync(int toDoTaskId)
        {
            return _context.ToDoTasks.FirstOrDefaultAsync(t => t.Id == toDoTaskId);
        }
    }
}
