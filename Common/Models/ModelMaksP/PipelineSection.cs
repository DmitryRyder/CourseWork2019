using System;
using System.Collections.Generic;

namespace Common.Models
{
    public class PipelineSection : BaseModel
    {
        public string NumberOfSection { get; set; }
        public int Length { get; set; }
        public DateTime LastRepair { get; set; }

        public Guid SteelPipeId { get; set; }
        public SteelPipe SteelPipe { get; set; }

        public List<InitialNode> InitialNodes { get; set; }
        public List<EndNode> EndNodes { get; set; }

        public PipelineSection()
        {
            InitialNodes = new List<InitialNode>();
            EndNodes = new List<EndNode>();
        }
    }
}
