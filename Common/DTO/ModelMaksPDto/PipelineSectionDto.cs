using System;
using System.ComponentModel;

namespace Common.DTO
{
    public class PipelineSectionDto : BaseDto
    {
        [DisplayName("Номер участка")]
        public string NumberOfSection { get; set; }
        [DisplayName("Длина учаска")]
        public int Length { get; set; }
        [DisplayName("Дата последнего ремонта")]
        public DateTime LastRepair { get; set; }
        public Guid SteelPipeId { get; set; }
        [DisplayName("Тип трубы")]
        public string SteelPipeName { get; set; }
    }
}
