﻿using System.Collections.Generic;

namespace Common.Models
{
    public class Room : BaseModel
    {
        public int Number{ get; set; }
        public double Area { get; set; }
        public int Floor { get; set; }
        public int Type_of_roomId { get; set; }
        public Type_of_room TypeOfRoom { get; set; }
        public List<Rooms_by_building> RoomsByBuilding { get; set; }
        public Room()
        {
            RoomsByBuilding = new List<Rooms_by_building>();
        }
    }
}
