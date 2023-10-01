using Application.DTO.PostDTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public static class AutoMapperConfig
{
    public static IMapper Initialize()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Post, PostDTO>();
            cfg.CreateMap<CreatePostDTO, Post>();
            cfg.CreateMap<UpdatePostDTO, Post>();
        }).CreateMapper();
        return config;
    }
}
