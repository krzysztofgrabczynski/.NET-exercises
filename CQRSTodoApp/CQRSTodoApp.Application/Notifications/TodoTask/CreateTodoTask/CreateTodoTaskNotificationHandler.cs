using MediatR;

namespace CQRSTodoApp.Application.Notifications.TodoTask.CreateTodoTask
{
    public class CreateTodoTaskNotificationHandler : INotificationHandler<CreateTodoTaskNotification>
    {
        public async Task Handle(CreateTodoTaskNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Simulation of the sending email...");
            await Task.CompletedTask;
        }
    }
}
