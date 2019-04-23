using System.Collections.Generic;

namespace Common.Models
{
    public class Organization : BaseModel
    {
        public string Name { get; set; }

        public string Post { get; set; }

        public List<Room_rental> Room_rentals { get; set; }

        public Organization()
        {
            Room_rentals = new List<Room_rental>();
        }
    }
}
