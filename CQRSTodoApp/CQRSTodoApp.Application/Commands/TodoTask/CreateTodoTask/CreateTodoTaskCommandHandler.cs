using AutoMapper;
using CQRSTodoApp.Domain.Infrastructure;
using MediatR;

namespace CQRSTodoApp.Application.Commands.TodoTask.CreateTodoTask
{
    public class CreateTodoTaskCommandHandler : IRequestHandler<CreateTodoTaskCommand>
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;
        private readonly IMapper _mapper;
        public CreateTodoTaskCommandHandler(IToDoTaskRepository toDoTaskRepository, IMapper mapper)
        {
            _toDoTaskRepository = toDoTaskRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateTodoTaskCommand request, CancellationToken cancellationToken)
        {
            var mappedNewTodoTask = _mapper.Map<Domain.Models.TodoTask>(request.newTodoTask);
            await _toDoTaskRepository.CreateToDoTaskAsync(mappedNewTodoTask);
        }
    }
}
