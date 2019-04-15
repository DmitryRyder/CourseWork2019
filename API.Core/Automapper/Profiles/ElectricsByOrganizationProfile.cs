using AutoMapper;
using Common.DTO;
using Common.Models;

namespace API.Core.Automapper.Profiles
{
    public class ElectricsByOrganizationProfile : Profile
    {
        public ElectricsByOrganizationProfile()
        {
            CreateMap<ElectricsByOrganization, ElectricsByOrganizationDto>();
            CreateMap<ElectricsByOrganizationDto, ElectricsByOrganization>();
        }
    }
}
