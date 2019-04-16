using AutoMapper;
using Common.DTO;
using Common.Models;

namespace API.Core.Automapper.Profiles
{
    class InitialNodeProfile : Profile
    {
        public InitialNodeProfile()
        {
           CreateMap<InitialNode, InitialNodeDto>()
                .ForMember(m => m.PipelineSectionNumber, o => o.MapFrom(s => s.PipelineSection.NumberOfSection))
                .ForMember(m => m.ThermalNodeName, o => o.MapFrom(s => s.ThermalNode.TypeOfNode.Name));
            CreateMap<InitialNodeDto, InitialNode>();
        }
    }
}
