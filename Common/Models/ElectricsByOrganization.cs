using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    public class ElectricsByOrganization : BaseModel
    {
        [ForeignKey("ElectricId ")]
        public Electric Electric { get; set; }

        [ForeignKey("OrganizationId")]
        public Organization Organization { get; set; }
    }
}
