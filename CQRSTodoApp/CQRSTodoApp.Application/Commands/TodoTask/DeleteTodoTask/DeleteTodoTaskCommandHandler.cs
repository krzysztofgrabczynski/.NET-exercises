using CQRSTodoApp.Domain.Infrastructure;
using MediatR;

namespace CQRSTodoApp.Application.Commands.TodoTask.DeleteTodoTask
{
    public class DeleteTodoTaskCommandHandler : IRequestHandler<DeleteTodoTaskCommand>
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;
        public DeleteTodoTaskCommandHandler(IToDoTaskRepository toDoTaskRepository)
        {
            _toDoTaskRepository = toDoTaskRepository;
        }

        public async Task Handle(DeleteTodoTaskCommand request, CancellationToken cancellationToken)
        {
            await _toDoTaskRepository.DeleteToDoTaskByIdAsync(request.Id);
        }
    }
}
