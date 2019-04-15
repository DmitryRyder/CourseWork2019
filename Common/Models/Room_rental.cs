using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    public class Room_rental : BaseModel
    {
        public DateTime InputDate { get; set; }
        public DateTime OutputDate { get; set; }
        //[ForeignKey("RoomId")]
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
        //[ForeignKey("OrganizationId")]
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}
