using AutoMapper;
using Common.DTO;
using Common.Models;

namespace API.Core.Automapper.Profiles
{
    class ThermalNetworkProfile : Profile
    {
        public ThermalNetworkProfile()
        {
            CreateMap<ThermalNetwork, ThermalNetworkDto>()
                .ForMember(m => m.OrganizationName, o => o.MapFrom(s => s.Organization.Name));
            CreateMap<ThermalNetworkDto, ThermalNetwork>();
        }
    }
}
