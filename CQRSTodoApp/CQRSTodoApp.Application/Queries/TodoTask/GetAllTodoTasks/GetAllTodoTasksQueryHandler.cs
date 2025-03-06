using CQRSTodoApp.Domain.Infrastructure;
using MediatR;

namespace CQRSTodoApp.Application.Queries.TodoTask.GetAllTodoTasks
{
    public class GetAllTodoTasksQueryHandler : IRequestHandler<GetAllTodoTasksQuery, List<Domain.Models.TodoTask>>
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;
        public GetAllTodoTasksQueryHandler(IToDoTaskRepository toDoTaskRepository)
        {
            _toDoTaskRepository = toDoTaskRepository;
        }

        public async Task<List<Domain.Models.TodoTask>> Handle(GetAllTodoTasksQuery request, CancellationToken cancellationToken)
        {
            var todoTasks = await _toDoTaskRepository.GetAllToDoTasksAsync();
            return todoTasks;
        }
    }
}
