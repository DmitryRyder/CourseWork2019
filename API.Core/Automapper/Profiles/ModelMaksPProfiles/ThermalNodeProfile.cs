using AutoMapper;
using Common.DTO;
using Common.Models;

namespace API.Core.Automapper.Profiles
{
    class ThermalNodeProfile : Profile
    {
        public ThermalNodeProfile()
        {
            CreateMap<ThermalNode, ThermalNodeDto>()
                .ForMember(m => m.ThermalNetworkName, o => o.MapFrom(s => s.ThermalNetwork.Name))
                .ForMember(m => m.TypeOfNodeName, o => o.MapFrom(s => s.TypeOfNode.Name));
            CreateMap<ThermalNodeDto, ThermalNode>();
        }
    }
}
