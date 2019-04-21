using System;
using System.ComponentModel;

namespace Common.DTO
{
    public class FetchThreeDto : BaseDto
    {
        [DisplayName("Дата ремонта")]
        public DateTime LastRepair { get; set; }

        [DisplayName("Номер участка")]
        public string Number { get; set; }

        [DisplayName("Длина участка")]
        public int Length { get; set; }

        [DisplayName("Тип труб")]
        public string TypeofPipe { get; set; }

        [DisplayName("Тепловая сеть")]
        public string ThermalNetworkName { get; set; }

        [DisplayName("Организация")]
        public string OrganizationName { get; set; }

    }
}
