using System;
using System.ComponentModel;

namespace Common.DTO
{
    public class InvoiceDto : BaseDto
    {
        [DisplayName("Номер счета")]
        public int Number { get; set; }
        [DisplayName("Дата создания счета")]
        public DateTime DateOfCreate { get; set; }
        [DisplayName("Дата оплаты счета")]
        public DateTime PaymentDate { get; set; }
        [DisplayName("Статус оплаты")]
        public bool StatusOfPayment { get; set; }
        public Guid Room_RentalId { get; set; }
    }
}
