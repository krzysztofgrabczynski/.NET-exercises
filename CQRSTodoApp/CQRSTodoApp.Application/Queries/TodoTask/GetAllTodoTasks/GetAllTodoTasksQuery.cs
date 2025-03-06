using MediatR;

namespace CQRSTodoApp.Application.Queries.TodoTask.GetAllTodoTasks
{
    public record GetAllTodoTasksQuery : IRequest<List<Domain.Models.TodoTask>>;
}
