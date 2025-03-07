using MediatR;

namespace CQRSTodoApp.Application.Notifications.TodoTask.CreateTodoTask
{
    public record CreateTodoTaskNotification() : INotification;
}
