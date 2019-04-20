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
                .ForMember(m => m.OrganizationName, o => o.MapFrom(s => s.Organization.Name))
                .ForMember(m => m.NetworkView, o => o.MapFrom(s => s.ThermalType.Name));
            CreateMap<ThermalNetworkDto, ThermalNetwork>();
        }
    }
}
