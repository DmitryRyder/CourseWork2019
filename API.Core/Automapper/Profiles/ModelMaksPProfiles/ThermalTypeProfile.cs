using AutoMapper;
using Common.DTO;
using Common.Models;

namespace API.Core.Automapper.Profiles
{
    class ThermalTypeProfile : Profile
    {
        public ThermalTypeProfile()
        {
            CreateMap<ThermalType, ThermalTypeDto>();
            CreateMap<ThermalTypeDto, ThermalType>();
        }
    }
}
