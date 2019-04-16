using System;
using System.Collections.Generic;

namespace Common.Models
{
    public class ThermalNetwork : BaseModel //типловая сеть
    {
        public string Name { get; set; }
        public int NumberOfNetwork { get; set; }
        public string NetworkView { get; set; } //"вид сети" - однотрубная/двухтрубная

        public Guid OrganizationID { get; set; }
        public OrganizationM Organization { get; set; }

        public List<ThermalNode> ThermalNodes { get; set; }

        public ThermalNetwork()
        {
            ThermalNodes = new List<ThermalNode>();
        }
    }
}
