using Application.DTO.BrandDTOs;
using Application.DTO.Components.Case;
using Application.DTO.Components.Case_Size;
using Application.DTO.Components.CPU;
using Application.DTO.Components.Drive;
using Application.DTO.Components.GPU;
using Application.DTO.Components.Motherboard;
using Application.DTO.Components.PowerSupllyDTOs;
using Application.DTO.Components.RAM;
using Application.DTO.Components.Slot;
using Application.DTO.Computer;
using Application.DTO.SeriesDTOs;
using Application.DTO.UserDTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Components;
using Domain.Entities.Components.Case;
using Domain.Entities.Components.CPU;
using Domain.Entities.Components.Drives;
using Domain.Entities.Components.GPU;
using Domain.Entities.Components.Motherboard;
using Domain.Entities.Components.RamMemory;
using Domain.Entities.Computer;
using Domain.Entities.Slots;

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

            cfg.CreateMap<SlotInterface, SlotDTO>();
            cfg.CreateMap<SlotDTO, SlotInterface>();
            cfg.CreateMap<AddSlotDTO, SlotInterface>();

            #region components
            //case
            cfg.CreateMap<Case, CaseDTO>();
            cfg.CreateMap<CaseDTO, Case>();
            cfg.CreateMap<AddCaseDTO, Case>();

            //ram
            cfg.CreateMap<RamMemories, RamDTO>();
            cfg.CreateMap<RamDTO, RamMemories>();
            cfg.CreateMap<AddRamDTO, RamMemories>();

            cfg.CreateMap<RamSpeed, RamSpeedDTO>();
            cfg.CreateMap<RamSpeedDTO, RamSpeed>();
            cfg.CreateMap<AddRamSpeedDTO, RamSpeed>();

            //cpu
            cfg.CreateMap<CPU, CpuDTO>();
            cfg.CreateMap<CpuDTO, CPU>();
            cfg.CreateMap<AddCpuDTO, CPU>();
            cfg.CreateMap<AddCpuDTO, CpuDTO>();

            cfg.CreateMap<SocketCPU, SocketCpuDTO>();
            cfg.CreateMap<SocketCpuDTO, SocketCPU>();
            cfg.CreateMap<AddSocketCpuDTO, SocketCPU>();
            cfg.CreateMap<AddSocketCpuDTO, SocketCpuDTO>();

            //psu
            cfg.CreateMap<PowerSupply, PowerSupplyDTO>();
            cfg.CreateMap<PowerSupplyDTO, PowerSupply>();
            cfg.CreateMap<AddPowerSupplyDTO, PowerSupply>();

            //motherboard
            cfg.CreateMap<Motherboard, MotherboardDTO>().ForMember(dest => dest.Memories, opt => opt.Ignore());
            cfg.CreateMap<MotherboardDTO, Motherboard>().ForMember(dest => dest.Memories, opt => opt.Ignore());
            cfg.CreateMap<AddMotherboardDTO, Motherboard>().ForMember(dest => dest.Memories, opt => opt.Ignore());
            cfg.CreateMap<UpdateMotherboardDTO, Motherboard>().ForMember(dest => dest.Memories, opt => opt.Ignore());

            cfg.CreateMap<MotheboardMemory, MotherboardMemoryDTO>();
            cfg.CreateMap<MotherboardMemoryDTO, MotheboardMemory>();
            cfg.CreateMap<AddMotherboardMemoryDTO, MotheboardMemory>();

            //gpu
            cfg.CreateMap<GPU, GpuDTO>();
            cfg.CreateMap<GpuDTO, GPU>();
            cfg.CreateMap<AddGpuDTO, GPU>();
            cfg.CreateMap<AddGpuDTO, GpuDTO>();

            //ssd
            cfg.CreateMap<Ssd, SsdDTO>();
            cfg.CreateMap<SsdDTO, Ssd>();
            cfg.CreateMap<AddSsdDTO, Ssd>();

            //hdd
            cfg.CreateMap<Hdd, HddDTO>();
            cfg.CreateMap<HddDTO, Hdd>();
            cfg.CreateMap<AddHddDTO, Hdd>();
            #endregion

            cfg.CreateMap<Computer, ComputerDTO>().ForMember(dest => dest.Ssds, opt => opt.Ignore()).ForMember(dest => dest.Drives, opt => opt.Ignore());
            cfg.CreateMap<ComputerDTO, Computer>().ForMember(dest => dest.Ssds, opt => opt.Ignore()).ForMember(dest => dest.Drives, opt => opt.Ignore());
            cfg.CreateMap<AddComputerDTO,Computer>().ForMember(dest => dest.Ssds, opt => opt.Ignore()).ForMember(dest => dest.Drives, opt => opt.Ignore());
            cfg.CreateMap<AddComputerDTO, ComputerDTO>().ForMember(dest => dest.Ssds, opt => opt.Ignore()).ForMember(dest => dest.Drives, opt => opt.Ignore());
            cfg.CreateMap<ComputerFormDTO, Computer>();
            cfg.CreateMap<Computer, ComputerFormDTO>();


        }).CreateMapper();
        return config;
    }
}
