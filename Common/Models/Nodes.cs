using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Nodes : BaseModel
    {
        public Guid ThermalNodeId { get; set; }
        public ThermalNode ThermalNode { get; set; }

        public Guid PipelineSectionId { get; set; }
        public PipelineSection PipelineSection { get; set; }
    }
}
