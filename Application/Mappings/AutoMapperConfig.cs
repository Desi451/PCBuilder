using Application.DTO.PostDTOs;
using Application.DTO.UserDTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public static class AutoMapperConfig
{
    public static IMapper Initialize()
    {
        var config = new MapperConfiguration(cfg =>
        {
            //post
            cfg.CreateMap<Post, PostDTO>();
            cfg.CreateMap<CreatePostDTO, Post>();
            cfg.CreateMap<UpdatePostDTO, Post>();
            //user
            cfg.CreateMap<User, UserDTO>();
        }).CreateMapper();
        return config;
    }
}
