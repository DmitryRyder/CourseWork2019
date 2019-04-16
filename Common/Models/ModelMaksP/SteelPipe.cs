using System.Collections.Generic;

namespace Common.Models
{
    public class SteelPipe : BaseModel
    {
        public string Name { get; set; }
        public int Diameter { get; set; }
        public int Thickness { get; set; }
        public int Volume { get; set; }
        public int Weight { get; set; }

        public List<PipelineSection> PipelineSections { get; set; }

        public SteelPipe()
        {
            PipelineSections = new List<PipelineSection>();
        }
    }
}
