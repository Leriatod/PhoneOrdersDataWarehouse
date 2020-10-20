using AutoMapper;
using PhoneDataWarehouse.Data.Models;
using PhoneDataWarehouse.Dtos;

namespace PhoneDataWarehouse.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // API TO DOMAIN
            CreateMap<RozetkaPhoneDto, Phone>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.ScreenSize, opt => opt.MapFrom(pdto => pdto.Display.ScreenSize))
                .ForMember(p => p.Resolution, opt => opt.MapFrom(pdto => pdto.Display.Resolution))
                .ForMember(p => p.Ram, opt => opt.MapFrom(pdto => pdto.Memory.Ram))
                .ForMember(p => p.InternalStorage, opt => opt.MapFrom(pdto => pdto.Memory.InternalStorage))
                .ForMember(p => p.CategoryName, opt => opt.MapFrom(pdto => pdto.Category.Name))
                .ForMember(p => p.OS, opt => opt.MapFrom(pdto => pdto.Category.OS));
            

        }

    }
}