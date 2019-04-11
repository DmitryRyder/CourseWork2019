using AutoMapper;
using Common.DTO;
using Common.Models;

namespace API.Core.Automapper.Profiles
{
    public class Room_rentalProfile : Profile
    {
        public Room_rentalProfile()
        {
            CreateMap<Room_rental, RoomRentalDto>();
            CreateMap<RoomRentalDto, Room_rental>();
        }
    }
}
