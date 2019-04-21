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
                .ForMember(m => m.ThermaNetworkName, o => o.MapFrom(s => s.ThermalNetwork.Name));
            CreateMap<PipelineSectionDto, PipelineSection>();
        }
    }
}
