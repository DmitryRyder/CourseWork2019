using System;
using System.ComponentModel;

namespace Common.DTO
{
    public class ThermalNodeDto : BaseDto
    {
        public Guid PipelineSectionId { get; set; }
        [DisplayName("Номер участка трубопровода")]
        public string PipelineSectionNumber { get; set; }

        public Guid TypeOfNodeId { get; set; }
        [DisplayName("Тип узла")]
        public string TypeOfNodeName { get; set; }
    }
}
