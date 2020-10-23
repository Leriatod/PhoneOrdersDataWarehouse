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
                .ForMember(p => p.ContactName, opt => opt.MapFrom(pdto => pdto.Contact.Name))
                .ForMember(p => p.ContactEmail, opt => opt.MapFrom(pdto => pdto.Contact.Email))
                .ForMember(p => p.ContactPhone, opt => opt.MapFrom(pdto => pdto.Contact.Phone));
                
            
            
            // CreateMap<AlloPhoneDto, Phone>()
            //     .ForMember(p => p.Id, opt => opt.Ignore())
            //     .ForMember(p => p.ScreenSize, opt => opt.MapFrom(pdto => pdto.ScreenDiagonal))
            //     .ForMember(p => p.CategoryName, opt => opt.MapFrom(pdto => pdto.Maker.Name));
            
            // // Domain to API
            // CreateMap<Phone, PhoneDto>()
            //     .ForMember(pdto => pdto.Display, opt => opt.MapFrom(p => new DisplayDto() { ScreenSize = p.ScreenSize, Resolution = p.Resolution } ))
            //     .ForMember(pdto => pdto.Memory, opt => opt.MapFrom(p => new MemoryDto() { Ram = p.Ram, InternalStorage = p.InternalStorage } ));
        }

    }
}