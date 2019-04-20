using AutoMapper;
using Common.DTO;
using Common.Models;

namespace API.Core.Automapper.Profiles
{
    class ThermalNodeProfile : Profile
    {
        public ThermalNodeProfile()
        {
            CreateMap<ThermalNode, ThermalNodeDto>();
            CreateMap<ThermalNodeDto, ThermalNode>();
        }
    }
}
