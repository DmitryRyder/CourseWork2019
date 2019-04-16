using System;
using System.ComponentModel;

namespace Common.DTO
{
    public class OrganizationWithInvoicesForReportsDto : BaseDto
    {
        [DisplayName("Номер счета")]
        public int InvoiceNumber { get; set; }
        [DisplayName("Название организации")]
        public string Name { get; set; }
        [DisplayName("Дата создания счета")]
        public DateTime InvoiceCreateDate { get; set; }
        [DisplayName("Дата оплаты")]
        public DateTime PaymentDate { get; set; }
        [DisplayName("Статус оплаты")]
        public bool IsPayment { get; set; }
    }
}
