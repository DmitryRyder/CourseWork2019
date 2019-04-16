using AutoMapper;
using Common.DTO;
using Common.Models;

namespace API.Core.Automapper.Profiles
{
    public class Room_rentalProfile : Profile
    {
        public Room_rentalProfile()
        {
            CreateMap<Room_rental, RoomRentalDto>()
                .ForMember(m => m.BuildingName, o => o.MapFrom(s => s.Room.Building.Name))
                .ForMember(m => m.OrganizationName, o => o.MapFrom(s => s.Organization.Name))
                .ForMember(m => m.RoomNumber, o => o.MapFrom(s => s.Room.Number));
            CreateMap<RoomRentalDto, Room_rental>();
        }
    }
}
