using CQRSTodoApp.Domain.Models;

namespace CQRSTodoApp.Domain.Infrastructure
{
    public interface IToDoTaskRepository
    {
        Task CreateToDoTaskAsync(ToDoTask toDoTask);
        Task<ToDoTask?> GetToDoTaskByIdAsync(int toDoTaskId);
        Task<List<ToDoTask>> GetAllToDoTasksAsync();
        Task<bool> DeleteToDoTaskByIdAsync(int toDoTaskId);
    }
}
