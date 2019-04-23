using System;
using System.Collections.Generic;

namespace Common.Models
{
    public class Room : BaseModel
    {
        public int Number { get; set; }
        public double Area { get; set; }
        public int Floor { get; set; }
        public Guid BuildingId { get; set; }
        public Building Building { get; set; }
        public List<Room_rental> Room_rentals { get; set; }

        public Room()
        {
            Room_rentals = new List<Room_rental>();
        }
    }
}
