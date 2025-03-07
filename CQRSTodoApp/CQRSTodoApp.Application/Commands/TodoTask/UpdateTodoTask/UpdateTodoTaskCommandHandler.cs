using CQRSTodoApp.Domain.Exceptions.TodoTask;
using CQRSTodoApp.Domain.Infrastructure;
using MediatR;

namespace CQRSTodoApp.Application.Commands.TodoTask.UpdateTodoTask
{
    public class UpdateTodoTaskCommandHandler : IRequestHandler<UpdateTodoTaskCommand>
    {
        private readonly IToDoTaskRepository _todoTaskRepository;

        public UpdateTodoTaskCommandHandler(IToDoTaskRepository todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }

        public async Task Handle(UpdateTodoTaskCommand request, CancellationToken cancellationToken)
        {
            var todoTask = await _todoTaskRepository.GetToDoTaskByIdAsync(request.updatedTodoTask.Id);
            if (todoTask is null)
            {
                throw new TodoTaskNotFoundException(request.updatedTodoTask.Id);
            }

            todoTask.Content = request.updatedTodoTask.Content ?? todoTask.Content;
            todoTask.Done = request.updatedTodoTask.Done ?? todoTask.Done;

            await _todoTaskRepository.UpdateToDoTaskAsync(todoTask);
        }
    }
}
