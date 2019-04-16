using System;
using System.Collections.Generic;

namespace Common.Models
{
    public class Room_rental : BaseModel
    {
        public DateTime InputDate { get; set; }
        public DateTime OutputDate { get; set; }
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public List<Invoice> Invoices { get; set; }

        public Room_rental()
        {
            Invoices = new List<Invoice>();
        }
    }
}
