using System.ComponentModel;

namespace Common.DTO
{
    public class Fetch3Dto : BaseDto
    {
        [DisplayName("Номер участка")]
        public int Number { get; set; }

        [DisplayName("Длина участка")]
        public int Length { get; set; }

        [DisplayName("Тип труб")]
        public string TypeofPipe { get; set; }

        [DisplayName("Тепловая сеть")]
        public string ThermalNetworkName { get; set; }

        [DisplayName("Тепловая сеть")]
        public string OrganizationName { get; set; }

    }
}
