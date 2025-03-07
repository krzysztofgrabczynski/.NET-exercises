using CQRSTodoApp.Application.Commands.TodoTask.CreateTodoTask;
using CQRSTodoApp.Application.Commands.TodoTask.DeleteTodoTask;
using CQRSTodoApp.Application.Queries.TodoTask.GetTodoTask;
using CQRSTodoApp.Application.Queries.TodoTask.GetAllTodoTasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CQRSTodoApp.Application.Dto.TodoTask;
using CQRSTodoApp.Application.Commands.TodoTask.UpdateTodoTask;
using CQRSTodoApp.Application.Notifications.TodoTask.CreateTodoTask;

namespace CQRSTodoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTaskController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IPublisher _publisher;

        public TodoTaskController(ISender sender, IPublisher publisher)
        {
            _sender = sender;
            _publisher = publisher;
        }

        [HttpGet("get-task/{id}")]
        public async Task<IActionResult> GetTodoTask(int id)
        {
            var todoTask = await _sender.Send(new GetTodoTaskQuery(id));
            return Ok(todoTask);
        }

        [HttpGet("list-tasks")]
        public async Task<IActionResult> GetAllTodoTasks()
        {
            var todoTasks = await _sender.Send(new GetAllTodoTasksQuery());
            return Ok(todoTasks);
        }

        [HttpPost("create-task")]
        public async Task<IActionResult> CreateTodoTask([FromBody] CreateTodoTaskDto newTodoTask)
        {
            await _sender.Send(new CreateTodoTaskCommand(newTodoTask));
            await _publisher.Publish(new CreateTodoTaskNotification());
            return Ok();
        }
        
        [HttpDelete("delete-task/{id}")]
        public async Task<IActionResult> DeleteTodoTask([FromBody] int id)
        {
            await _sender.Send(new DeleteTodoTaskCommand(id));
            return Ok();
        }

        [HttpPut("update-task")]
        public async Task<IActionResult> UpdateTodoTask([FromBody] UpdateTodoTaskDto updatedTodoTask)
        {
            await _sender.Send(new UpdateTodoTaskCommand(updatedTodoTask));
            return Ok();
        }
    }
}
