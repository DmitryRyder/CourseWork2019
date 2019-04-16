using AutoMapper;
using Common.DTO;
using Common.Models;

namespace API.Core.Automapper.Profiles
{
    class SteelPipeProfile : Profile
    {
        public SteelPipeProfile()
        {
            CreateMap<SteelPipe, SteelPipeDto>();
            CreateMap<SteelPipeDto, SteelPipe>();
        }
    }
}
