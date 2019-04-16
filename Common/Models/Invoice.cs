using System;

namespace Common.Models
{
    public class Invoice : BaseModel
    {
        public int Number { get; set; }
        public DateTime DateOfCreate { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool StatusOfPayment { get; set; }
        public Guid Room_RentalId { get; set; }
        public Room_rental Room_Rental { get; set; }
    }
}
