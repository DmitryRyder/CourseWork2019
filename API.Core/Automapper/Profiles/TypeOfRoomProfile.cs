using AutoMapper;
using Common.DTO;
using Common.Models;

namespace API.Core.Automapper.Profiles
{
    class Type_of_room : Profile
    {
        public Type_of_room()
        {
            CreateMap<Type_of_room, TypeOfRoomDto>();
            CreateMap<TypeOfRoomDto, Type_of_room>();
        }
    }
}
