using System;
using System.Collections.Generic;

namespace Common.Models
{
    public class ThermalNode : BaseModel //тепловой узел
    {
        public Guid ThermalNetworkID { get; set; }
        public ThermalNetwork ThermalNetwork { get; set; }

        public Guid TypeOfNodeID { get; set; }
        public TypeOfNode TypeOfNode { get; set; }

        public List<InitialNode> InitialNodes { get; set; }
        public List<EndNode> EndNodes { get; set; }

        public ThermalNode()
        {
            InitialNodes = new List<InitialNode>();
            EndNodes = new List<EndNode>();
        }
    }
}
