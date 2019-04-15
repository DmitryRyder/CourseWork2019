using AutoMapper;
using Common.DTO;
using Common.Models;

namespace API.Core.Automapper.Profiles
{
    class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomDto>();
            CreateMap<RoomDto, Room>()
                .ForMember(m => m.BuildingId, o => o.MapFrom(s => s.BuildingId))
                .ForMember(m => m.Type_of_roomId, o => o.MapFrom(s => s.Type_of_roomId));
        }
    }
}
