using System.ComponentModel;

namespace Common.DTO
{
    public class WaterVolumeDto : BaseDto
    {
        [DisplayName("Орган управления")]
        public string ManagementBodyName { get; set; }
        [DisplayName("Организация")]
        public string OrganizationName { get; set; }
        [DisplayName("Тепловая сеть")]
        public string ThermalNetworkName { get; set; }
        [DisplayName("Объем воды")]
        public double WaterVolume { get; set; }

    }
}
