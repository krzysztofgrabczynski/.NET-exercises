using AutoMapper;
using CQRSTodoApp.Application.Mapping;

namespace CQRSTodoApp.Application.Dto.TodoTask
{
    public record CreateTodoTaskDto : IMapFrom<Domain.Models.TodoTask>
    {
        public string Content { get; init; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTodoTaskDto, Domain.Models.TodoTask>();
        }
    }
}
