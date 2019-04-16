using AutoMapper;
using Common.DTO;
using Common.Models;

namespace API.Core.Automapper.Profiles
{
    class EndNodeProfile : Profile
    {
        public EndNodeProfile()
        {
            CreateMap<EndNode, EndNodeDto>()
                .ForMember(m => m.PipelineSectionNumber, o => o.MapFrom(s => s.PipelineSection.NumberOfSection))
                .ForMember(m => m.ThermalNodeName, o => o.MapFrom(s => s.ThermalNode.TypeOfNode.Name));
            CreateMap<EndNodeDto, EndNode>();
        }
    }
}
