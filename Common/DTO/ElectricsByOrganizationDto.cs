using System;
using System.ComponentModel;

namespace Common.DTO
{
    public class ElectricsByOrganizationDto : BaseDto
    {
        //[ForeignKey("ElectricId ")]
        public Guid ElectricId { get; set; }
        [DisplayName("Оборудование")]
        public string ElectricName { get; set; }

        //[ForeignKey("OrganizationId")]
        public Guid OrganizationId { get; set; }
        [DisplayName("Организация")]
        public string OrganizationName { get; set; }
    }
}
