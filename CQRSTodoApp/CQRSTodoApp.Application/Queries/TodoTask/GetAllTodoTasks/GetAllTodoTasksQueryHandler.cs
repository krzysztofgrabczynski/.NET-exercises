using AutoMapper;
using CQRSTodoApp.Application.Dto.TodoTask;
using CQRSTodoApp.Domain.Infrastructure;
using MediatR;

namespace CQRSTodoApp.Application.Queries.TodoTask.GetAllTodoTasks
{
    public class GetAllTodoTasksQueryHandler : IRequestHandler<GetAllTodoTasksQuery, List<RetrieveTodoTaskDto>>
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;
        private readonly IMapper _mapper;
        public GetAllTodoTasksQueryHandler(IToDoTaskRepository toDoTaskRepository, IMapper mapper)
        {
            _toDoTaskRepository = toDoTaskRepository;
            _mapper = mapper;
        }

        public async Task<List<RetrieveTodoTaskDto>> Handle(GetAllTodoTasksQuery request, CancellationToken cancellationToken)
        {
            var todoTasks = await _toDoTaskRepository.GetAllToDoTasksAsync();
            var mappedTodoTasks = new List<RetrieveTodoTaskDto>();
            foreach (var todoTask in todoTasks)
            {
                var mappedTodoTask = _mapper.Map<RetrieveTodoTaskDto>(todoTask);
                mappedTodoTasks.Add(mappedTodoTask);
            }

            return mappedTodoTasks;
        }
    }
}
