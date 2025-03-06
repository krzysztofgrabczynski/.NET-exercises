using CQRSTodoApp.Application.Commands.TodoTask.CreateTodoTask;
using CQRSTodoApp.Application.Commands.TodoTask.DeleteTodoTask;
using CQRSTodoApp.Application.Queries.TodoTask.GetTodoTask;
using CQRSTodoApp.Application.Queries.TodoTask.GetAllTodoTasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CQRSTodoApp.Application.Dto.TodoTask;

namespace CQRSTodoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTaskController : ControllerBase
    {
        private readonly ISender _sender;

        public TodoTaskController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("get-task/{id}")]
        public async Task<IActionResult> GetTodoTask(int id)
        {
            var query = new GetTodoTaskQuery(id);
            var todoTask = await _sender.Send(query);
            return Ok(todoTask);
        }

        [HttpGet("list-tasks")]
        public async Task<IActionResult> GetAllTodoTasks()
        {
            var query = new GetAllTodoTasksQuery();
            var todoTasks = await _sender.Send(query);
            return Ok(todoTasks);
        }

        [HttpPost("create-task")]
        public async Task<IActionResult> CreateTodoTask([FromBody] CreateTodoTaskDto newTodoTask)
        {
            var command = new CreateTodoTaskCommand(newTodoTask.Content);
            await _sender.Send(command);
            return Ok();
        }

        [HttpDelete("delete-task/{id}")]
        public async Task<IActionResult> DeleteTodoTask([FromBody] int id)
        {
            var command = new DeleteTodoTaskCommand(id);
            await _sender.Send(command);
            return Ok();
        }
    }
}
