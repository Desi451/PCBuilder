using Application.DTO.BrandDTOs;
using Application.DTO.Components.Case;
using Application.DTO.Components.Case_Size;
using Application.DTO.SeriesDTOs;
using Application.DTO.UserDTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Components.Case;

namespace Application.Mappings;

public static class AutoMapperConfig
{
    public static IMapper Initialize()
    {
        var config = new MapperConfiguration(cfg =>
        {
            //user
            cfg.CreateMap<User, UserDTO>();
            cfg.CreateMap<UserDTO, User>();
            cfg.CreateMap<AddUserDTO, User>();
            cfg.CreateMap<LoginUserDTO, User>();

            //brand & series
            cfg.CreateMap<Brand, BrandDTO>();
            cfg.CreateMap<BrandDTO, Brand>();
            cfg.CreateMap<AddBrandDTO,Brand>();

            cfg.CreateMap<Series, SeriesDTO>();
            cfg.CreateMap<SeriesDTO, Series>();
            cfg.CreateMap<AddSeriesDTO, Series>();

            #region components
            //case
            cfg.CreateMap<Case, CaseDTO>();
            cfg.CreateMap<CaseDTO, Case>();
            cfg.CreateMap<AddCaseDTO, Case>();

            #endregion

        }).CreateMapper();
        return config;
    }
}
