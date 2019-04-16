using System;

namespace Common.Models
{
    public class EndNode : BaseModel
    {
        public Guid PipelineSectionId { get; set; }
        public PipelineSection PipelineSection { get; set; }

        public Guid ThermalNodeId { get; set; }
        public ThermalNode ThermalNode { get; set; }
    }
}
