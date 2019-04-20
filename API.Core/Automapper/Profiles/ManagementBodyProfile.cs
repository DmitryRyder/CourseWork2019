using AutoMapper;
using Common.DTO;
using Common.Models;

namespace API.Core.Automapper.Profiles
{
    class ManagementBodyProfile : Profile
    {
        public ManagementBodyProfile()
        {
            CreateMap<ManagementBody, ManagementBodyDto>();
            CreateMap<ManagementBodyDto, ManagementBody>();
        }
    }
}
