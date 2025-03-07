using CQRSTodoApp.Application.Dto.TodoTask;
using MediatR;

namespace CQRSTodoApp.Application.Commands.TodoTask.UpdateTodoTask
{
    public record UpdateTodoTaskCommand(UpdateTodoTaskDto updatedTodoTask) : IRequest;
}
