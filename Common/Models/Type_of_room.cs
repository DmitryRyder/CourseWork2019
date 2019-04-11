using System.Collections.Generic;

namespace Common.Models
{
    public class Type_of_room : BaseModel
    {
        public string Name { get; set; }

        public IList<Room> rooms { get; set; }

        public Type_of_room()
        {
            rooms = new List<Room>();
        }
    }
}
