using MediatR;

namespace CQRSTodoApp.Application.Commands.TodoTask.CreateTodoTask
{
    public record CreateTodoTaskCommand(string Content) : IRequest;
}
