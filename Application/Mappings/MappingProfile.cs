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

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //user
        CreateMap<User, UserDTO>().ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.UserName));
        CreateMap<AddUserDTO, User>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Login));

        //brand & series
        CreateMap<Brand, BrandDTO>();
        CreateMap<BrandDTO, Brand>();
        CreateMap<AddBrandDTO,Brand>();

        CreateMap<Series, SeriesDTO>();
        CreateMap<SeriesDTO, Series>();
        CreateMap<AddSeriesDTO, Series>();

        CreateMap<SlotInterface, SlotDTO>();
        CreateMap<SlotDTO, SlotInterface>();
        CreateMap<AddSlotDTO, SlotInterface>();

        #region components
        //case
        CreateMap<Case, CaseDTO>();
        CreateMap<CaseDTO, Case>();
        CreateMap<AddCaseDTO, Case>();

        //ram
        CreateMap<RamMemories, RamDTO>();
        CreateMap<RamDTO, RamMemories>();
        CreateMap<AddRamDTO, RamMemories>();

        CreateMap<RamSpeed, RamSpeedDTO>();
        CreateMap<RamSpeedDTO, RamSpeed>();
        CreateMap<AddRamSpeedDTO, RamSpeed>();

        //cpu
        CreateMap<CPU, CpuDTO>();
        CreateMap<CpuDTO, CPU>();
        CreateMap<AddCpuDTO, CPU>();
        CreateMap<AddCpuDTO, CpuDTO>();

        CreateMap<SocketCPU, SocketCpuDTO>();
        CreateMap<SocketCpuDTO, SocketCPU>();
        CreateMap<AddSocketCpuDTO, SocketCPU>();
        CreateMap<AddSocketCpuDTO, SocketCpuDTO>();

        //psu
        CreateMap<PowerSupply, PowerSupplyDTO>();
        CreateMap<PowerSupplyDTO, PowerSupply>();
        CreateMap<AddPowerSupplyDTO, PowerSupply>();

        //motherboard
        CreateMap<Motherboard, MotherboardDTO>().ForMember(dest => dest.Memories, opt => opt.Ignore());
        CreateMap<MotherboardDTO, Motherboard>().ForMember(dest => dest.Memories, opt => opt.Ignore());
        CreateMap<AddMotherboardDTO, Motherboard>().ForMember(dest => dest.Memories, opt => opt.Ignore());
        CreateMap<UpdateMotherboardDTO, Motherboard>().ForMember(dest => dest.Memories, opt => opt.Ignore());

        CreateMap<MotheboardMemory, MotherboardMemoryDTO>();
        CreateMap<MotherboardMemoryDTO, MotheboardMemory>();
        CreateMap<AddMotherboardMemoryDTO, MotheboardMemory>();

        //gpu
        CreateMap<GPU, GpuDTO>();
        CreateMap<GpuDTO, GPU>();
        CreateMap<AddGpuDTO, GPU>();
        CreateMap<AddGpuDTO, GpuDTO>();

        //ssd
        CreateMap<Ssd, SsdDTO>();
        CreateMap<SsdDTO, Ssd>();
        CreateMap<AddSsdDTO, Ssd>();

        //hdd
        CreateMap<Hdd, HddDTO>();
        CreateMap<HddDTO, Hdd>();
        CreateMap<AddHddDTO, Hdd>();
        #endregion

        CreateMap<Computer, ComputerDTO>().ForMember(dest => dest.Ssds, opt => opt.Ignore()).ForMember(dest => dest.Drives, opt => opt.Ignore());
        CreateMap<ComputerDTO, Computer>().ForMember(dest => dest.Ssds, opt => opt.Ignore()).ForMember(dest => dest.Drives, opt => opt.Ignore());
        CreateMap<AddComputerDTO,Computer>().ForMember(dest => dest.Ssds, opt => opt.Ignore()).ForMember(dest => dest.Drives, opt => opt.Ignore());
        CreateMap<AddComputerDTO, ComputerDTO>().ForMember(dest => dest.Ssds, opt => opt.Ignore()).ForMember(dest => dest.Drives, opt => opt.Ignore());
        CreateMap<ComputerFormDTO, Computer>();
        CreateMap<Computer, ComputerFormDTO>();
    }
}
