using CQRSTodoApp.Domain.Infrastructure;
using MediatR;

namespace CQRSTodoApp.Application.Commands.TodoTask.CreateTodoTask
{
    public class CreateTodoTaskCommandHandler : IRequestHandler<CreateTodoTaskCommand>
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;
        public CreateTodoTaskCommandHandler(IToDoTaskRepository toDoTaskRepository)
        {
            _toDoTaskRepository = toDoTaskRepository;
        }

        public async Task Handle(CreateTodoTaskCommand request, CancellationToken cancellationToken)
        {
            var toDoTask = new Domain.Models.TodoTask()
            {
                Content = request.Content,
                Done = false,
            };
            await _toDoTaskRepository.CreateToDoTaskAsync(toDoTask);
        }
    }
}
