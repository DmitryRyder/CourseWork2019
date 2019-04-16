using System;
using System.ComponentModel;

namespace Common.DTO
{
    public class ThermalNodeDto : BaseDto
    {
        public Guid ThermalNetworkID { get; set; }
        [DisplayName("Название сети")]
        public string ThermalNetworkName { get; set; }

        public Guid TypeOfNodeID { get; set; }
        [DisplayName("Тип узла")]
        public string TypeOfNodeName { get; set; }
    }
}
