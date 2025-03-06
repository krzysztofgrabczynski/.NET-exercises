﻿using AutoMapper;
using CQRSTodoApp.Application.Mapping;

namespace CQRSTodoApp.Application.Dto.TodoTask
{
    public record RetrieveTodoTaskDto : IMapFrom<Domain.Models.TodoTask>
    {
        public string Content { get; init; }
        public bool Done { get; init; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.TodoTask, RetrieveTodoTaskDto>();
        }
    }
}
