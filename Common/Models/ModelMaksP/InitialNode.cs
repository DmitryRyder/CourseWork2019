using System;

namespace Common.Models
{
    public class InitialNode : BaseModel
    {
        public Guid PipelineSectionId { get; set; }
        public virtual PipelineSection PipelineSection { get; set; }

        public Guid ThermalNodeId { get; set; }
        public virtual ThermalNode ThermalNode { get; set; }
    }
}
