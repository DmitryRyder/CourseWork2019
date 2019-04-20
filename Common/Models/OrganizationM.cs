using System;
using System.Collections.Generic;

namespace Common.Models
{
    public class OrganizationM : BaseModel
    {
        public string Name { get; set; }

        public Guid ManagementBodyID { get; set; }
        public ManagementBody ManagementBody { get; set; }

        public IList<ThermalNetwork> ThermalNetworks { get; set; }

        public OrganizationM()
        {
            ThermalNetworks = new List<ThermalNetwork>();
        }
    }
}
