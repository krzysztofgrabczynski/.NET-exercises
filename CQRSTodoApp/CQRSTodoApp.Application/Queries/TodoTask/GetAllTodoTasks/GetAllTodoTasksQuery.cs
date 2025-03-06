using CQRSTodoApp.Application.Dto.TodoTask;
using MediatR;

namespace CQRSTodoApp.Application.Queries.TodoTask.GetAllTodoTasks
{
    public record GetAllTodoTasksQuery : IRequest<List<RetrieveTodoTaskDto>>;
}
