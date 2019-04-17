using System;

namespace Common.Models
{
    public class ThermalNode : BaseModel //тепловой узел
    {
        public int Number { get; set; }
        public Guid TypeOfNodeId { get; set; }
        public TypeOfNode TypeOfNode { get; set; }
        public Guid PipelineSectionId { get; set; }
        public PipelineSection PipelineSection { get; set; }
    }
}
