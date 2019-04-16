using System;
using System.ComponentModel;

namespace Common.DTO
{
    public class ThermalNodeDto : BaseDto
    {
        public Guid ThermalNetworkId { get; set; }
        [DisplayName("Название сети")]
        public string ThermalNetworkName { get; set; }

        public Guid TypeOfNodeId { get; set; }
        [DisplayName("Тип узла")]
        public string TypeOfNodeName { get; set; }
    }
}
