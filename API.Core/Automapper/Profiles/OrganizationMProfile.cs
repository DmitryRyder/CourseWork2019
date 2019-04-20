using AutoMapper;
using Common.DTO;
using Common.Models;

namespace API.Core.Automapper.Profiles
{
    class OrganizationMProfile : Profile
    {
        public OrganizationMProfile()
        {
            CreateMap<OrganizationM, OrganizationMDto>()
                .ForMember(m => m.ManagementBodyName, o => o.MapFrom(s => s.ManagementBody.Name));
            CreateMap<OrganizationMDto, OrganizationM>();
        }
    }
}
