using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class Rooms_by_building
    {
        public int Buildings_Id { get; set; }
        public Building Building { get; set; }
        public int Rooms_Id { get; set; }
        public Room Room { get; set; }
    }
}
