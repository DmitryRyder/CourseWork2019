using System.Collections.Generic;

namespace Common.Models
{
    public class TypeOfNode : BaseModel //тип узла (Тепловой колодец, Тепловой пункт, Потребитель)
    {
        public string Name { get; set; }

        public List<ThermalNode> ThermalNodes { get; set; }

        public TypeOfNode()
        {
            ThermalNodes = new List<ThermalNode>();
        }
    }
}
