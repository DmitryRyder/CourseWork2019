using System.Collections.Generic;

namespace Common.Models
{
    public class Electric : BaseModel
    {
        public string Name { get; set; }
        public double Power { get; set; }
        public double UsingOfDay { get; set; }

        public IList<ElectricsByOrganization> ElectricsByOrganization { get; set; }
        public IList<Lighting> Lightings { get; set; }
        public Electric()
        {
            ElectricsByOrganization = new List<ElectricsByOrganization>();
            Lightings = new List<Lighting>();
        }
    }
}
