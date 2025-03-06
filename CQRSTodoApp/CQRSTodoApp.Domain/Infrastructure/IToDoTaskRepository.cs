using CQRSTodoApp.Domain.Models;

namespace CQRSTodoApp.Domain.Infrastructure
{
    public interface IToDoTaskRepository
    {
        Task CreateToDoTaskAsync(TodoTask toDoTask);
        Task<TodoTask?> GetToDoTaskByIdAsync(int toDoTaskId);
        Task<List<TodoTask>> GetAllToDoTasksAsync();
        Task<bool> DeleteToDoTaskByIdAsync(int toDoTaskId);
    }
}
