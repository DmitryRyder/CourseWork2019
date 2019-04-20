using System;
using System.ComponentModel;

namespace Common.DTO
{
    public class PipelineSectionDto : BaseDto
    {
        public Guid ThermalNetworkId { get; set; }
        [DisplayName("Номер участка")]
        public string NumberOfSection { get; set; }
        [DisplayName("Длина учаска")]
        public int Length { get; set; }
        [DisplayName("Дата последнего ремонта")]
        public DateTime LastRepair { get; set; }
        public Guid SteelPipeId { get; set; }
        [DisplayName("Труба")]
        public string SteelPipeName { get; set; }
        public ThermalNodeDto InitialThermalNode { get; set;}
        public ThermalNodeDto EndThermalNode { get; set; }
        [DisplayName("Начальный узел")]
        public string InitialThermalNodeNumber { get; set; }
        [DisplayName("Конечный узел")]
        public string EndThermalNodeNumber { get; set; }
    }
}
