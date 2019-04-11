using System;

namespace Common.Models
{
    public class Room_rental : BaseModel
    {
        public DateTime InputDate { get; set; }
        public DateTime OutputDate { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}
