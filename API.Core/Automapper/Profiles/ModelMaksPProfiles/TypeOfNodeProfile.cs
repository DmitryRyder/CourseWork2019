using AutoMapper;
using Common.DTO;
using Common.Models;

namespace API.Core.Automapper.Profiles
{
    class TypeOfNodeProfile : Profile
    {
        public TypeOfNodeProfile()
        {
            CreateMap<TypeOfNode, TypeOfNodeDto>();
            CreateMap<TypeOfNodeDto, TypeOfNode>();
        }
    }
}
