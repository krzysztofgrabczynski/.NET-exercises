using AutoMapper;
using CQRSTodoApp.Application.Dto.TodoTask;
using CQRSTodoApp.Application.Mapping;
using MediatR;

namespace CQRSTodoApp.Application.Queries.TodoTask.GetTodoTask
{
    public record GetTodoTaskQuery(int Id) : IRequest<RetrieveTodoTaskDto>;

}
