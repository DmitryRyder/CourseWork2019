using System.Collections.Generic;

namespace Common.Models
{
    public class Room : BaseModel
    {
        public int Number { get; set; }
        public double Area { get; set; }
        public int Floor { get; set; }
        public int Type_of_roomId { get; set; }
        public Type_of_room TypeOfRoom { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }
        public List<Room_rental> Room_rentals { get; set; }

        public Room()
        {
            Room_rentals = new List<Room_rental>();
        }
    }
}
