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
                .ForMember(m => m.PipelineSectionNumber, o => o.MapFrom(s => s.PipelineSection.NumberOfSection))
                .ForMember(m => m.TypeOfNodeName, o => o.MapFrom(s => s.TypeOfNode.Name));
            CreateMap<ThermalNodeDto, ThermalNode>();
        }
    }
}
