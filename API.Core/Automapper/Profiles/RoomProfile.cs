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
                .ForMember(m => m.BuildingName, o => o.MapFrom(s => s.Building.Name));
            CreateMap<RoomDto, Room>()
                .ForMember(m => m.BuildingId, o => o.MapFrom(s => s.BuildingId));
        }
    }
}
