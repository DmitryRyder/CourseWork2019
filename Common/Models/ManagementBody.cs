using System.Collections.Generic;

namespace Common.Models
{
    public class ManagementBody : BaseModel
    {
        public string Name { get; set; }

        public List<OrganizationM> Organizations { get; set; }

        public ManagementBody()
        {
            Organizations = new List<OrganizationM>();
        }
    }
}
