
using System;

namespace Common.Models
{
    public class Lighting : BaseModel
    {
        public Guid ElectricId { get; set; }
        public Electric Electric { get; set; }
    }
}
