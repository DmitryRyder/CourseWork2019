using AutoMapper;
using Common.DTO;
using Common.Models;

namespace API.Core.Automapper.Profiles
{
    class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomDto>()
                .ForMember(s => s.TypeOfRoom, o => o.MapFrom(m => m.TypeOfRoom.Name));
            CreateMap<RoomDto, Room>();
        }
    }
}
