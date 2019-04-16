using AutoMapper;
using Common.DTO;
using Common.Models;

namespace API.Core.Automapper.Profiles
{
    public class ElectricsByOrganizationProfile : Profile
    {
        public ElectricsByOrganizationProfile()
        {
            CreateMap<ElectricsByOrganization, ElectricsByOrganizationDto>()
                .ForMember(m => m.OrganizationName, o => o.MapFrom(s => s.Organization.Name))
                .ForMember(m => m.ElectricName, o => o.MapFrom(s => s.Electric.Name));
            CreateMap<ElectricsByOrganizationDto, ElectricsByOrganization>();
        }
    }
}
