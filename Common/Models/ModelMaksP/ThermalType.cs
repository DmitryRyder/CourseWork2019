using System.Collections.Generic;

namespace Common.Models
{
    public class ThermalType : BaseModel
    {
        public string Name { get; set; }

        public List<ThermalNetwork> ThermalNetworks { get; set; }

        public ThermalType()
        {
            ThermalNetworks = new List<ThermalNetwork>();
        }
    }
}
