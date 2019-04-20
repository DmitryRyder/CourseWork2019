using System;
using System.Collections.Generic;

namespace Common.Models
{
    public class ThermalNetwork : BaseModel //типловая сеть
    {
        public string Name { get; set; }
        public int NumberOfNetwork { get; set; }
        public Guid ThermalTypeId { get; set; }
        public ThermalType ThermalType { get; set; } //"вид сети" - однотрубная/двухтрубная

        public Guid OrganizationId { get; set; }
        public OrganizationM Organization { get; set; }

        public List<PipelineSection> PipelineSections { get; set; }

        public ThermalNetwork()
        {
            PipelineSections = new List<PipelineSection>();
        }
    }
}
