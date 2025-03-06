using AutoMapper;
using CQRSTodoApp.Application.Dto.TodoTask;
using CQRSTodoApp.Domain.Infrastructure;
using MediatR;

namespace CQRSTodoApp.Application.Queries.TodoTask.GetTodoTask
{
    public class GetTodoTaskQueryHandler : IRequestHandler<GetTodoTaskQuery, RetrieveTodoTaskDto>
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;
        private readonly IMapper _mapper;
        public GetTodoTaskQueryHandler(IToDoTaskRepository toDoTaskRepository, IMapper mapper)
        {
            _toDoTaskRepository = toDoTaskRepository;
            _mapper = mapper;
        }

        public async Task<RetrieveTodoTaskDto> Handle(GetTodoTaskQuery request, CancellationToken cancellationToken)
        {
            var todoTask = await _toDoTaskRepository.GetToDoTaskByIdAsync(request.Id);
            if (todoTask is null)
            {
                throw new ArgumentException();
            }

            var mappedTodoTask = _mapper.Map<RetrieveTodoTaskDto>(todoTask);
            return mappedTodoTask;
        }
    }
}
