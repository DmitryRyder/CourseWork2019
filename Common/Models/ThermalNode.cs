using System;
using System.Collections.Generic;

namespace Common.Models
{
    public class ThermalNode : BaseModel //тепловой узел
    {
        public int Number { get; set; }
        public Guid TypeOfNodeId { get; set; }
        public TypeOfNode TypeOfNode { get; set; }
        public List<Nodes> Nodes { get; set; }

        public ThermalNode()
        {
            Nodes = new List<Nodes>();
        }
    }
}
