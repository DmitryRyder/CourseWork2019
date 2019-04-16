using System;
using System.ComponentModel;

namespace Common.DTO
{
    public class EndNodeDto : BaseDto
    {
        public Guid PipelineSectionId { get; set; }
        [DisplayName("Номер участка сети")]
        public string PipelineSectionNumber { get; set; }
        public Guid ThermalNodeId { get; set; }
        [DisplayName("Название узла")]
        public string ThermalNodeName { get; set; }
    }
}
