using System;
using System.ComponentModel;

namespace Common.DTO
{
    public class TypeOfNodeDto : BaseDto
    {
        [DisplayName("Тип узла")]
        public string Name { get; set; }
    }
}
