using System;
using System.ComponentModel;

namespace Common.DTO
{
    public class ThermalTypeDto : BaseDto
    {
        [DisplayName("Тип сети")]
        public string Name { get; set; }
    }
}
