using AutoMapper;
using Common.DTO;
using Common.Models;

namespace API.Core.Automapper.Profiles
{
    class PipelineSectionProfile : Profile
    {
        public PipelineSectionProfile()
        {
            CreateMap<PipelineSection, PipelineSectionDto>()
                .ForMember(m => m.SteelPipeName, o => o.MapFrom(s => s.SteelPipe.Name));
            CreateMap<PipelineSectionDto, PipelineSection>();
        }
    }
}
