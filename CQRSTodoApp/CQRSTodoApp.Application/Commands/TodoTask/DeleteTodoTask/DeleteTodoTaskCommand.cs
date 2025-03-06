using AutoMapper;
using CQRSTodoApp.Application.Mapping;
using MediatR;

namespace CQRSTodoApp.Application.Commands.TodoTask.DeleteTodoTask
{
    public record DeleteTodoTaskCommand(int Id) : IRequest;
}
