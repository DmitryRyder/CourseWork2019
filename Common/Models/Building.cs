using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class Building : BaseModel
    {
        public string Name { get; set; }
        public string Post { get; set; }
        public int Number_of_floors { get; set; }

        public List<Rooms_by_building> RoomsByBuilding { get; set; }
        public Building()
        {
            RoomsByBuilding = new List<Rooms_by_building>();
        }
    }
}
