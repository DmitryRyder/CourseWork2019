using AutoMapper;
using Common.DTO;
using Common.Models;
using System.Linq;

namespace API.Core.Automapper.Profiles
{
    class PipelineSectionProfile : Profile
    {
        public PipelineSectionProfile()
        {
            CreateMap<PipelineSection, PipelineSectionDto>()
                .ForMember(m => m.SteelPipeName, o => o.MapFrom(s => s.SteelPipe.Name))
                .ForMember(m => m.InitialThermalNodeNumber, o => o.MapFrom(s => s.Nodes.FirstOrDefault().ThermalNode.Number))
                .ForMember(m => m.EndThermalNodeNumber, o => o.MapFrom(s => s.Nodes.LastOrDefault().ThermalNode.Number));
            CreateMap<PipelineSectionDto, PipelineSection>();
        }
    }
}
