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
                
            
            
            CreateMap<AlloPhoneDto, Phone>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.ContactName, opt => opt.MapFrom(pdto => pdto.Buyer.Name))
                .ForMember(p => p.ContactEmail, opt => opt.MapFrom(pdto => pdto.Buyer.Email))
                .ForMember(p => p.ContactPhone, opt => opt.MapFrom(pdto => pdto.Buyer.Phone))
                .ForMember(p => p.PurchaseDate, opt => opt.MapFrom(pdto => pdto.Date));
            
            // Domain to API
            CreateMap<Phone, PhoneDto>()
                .ForMember(pdto => pdto.Contact, opt => opt.MapFrom(p => new ContactDto() { Name = p.ContactName, Email = p.ContactEmail, Phone = p.ContactPhone } ));
        }

    }
}