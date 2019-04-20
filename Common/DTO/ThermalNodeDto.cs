using System;

namespace Common.DTO
{
    public class ThermalNodeDto : BaseDto
    {
        public int Number { get; set; }
        public Guid TypeOfNodeId { get; set; }
    }
}
