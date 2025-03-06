using CQRSTodoApp.Application.Dto.TodoTask;
using MediatR;

namespace CQRSTodoApp.Application.Commands.TodoTask.CreateTodoTask
{
    public record CreateTodoTaskCommand(CreateTodoTaskDto newTodoTask) : IRequest;
}
