
using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class ElectricsByOrganization
    {
        [Key]
        public int ElectricId { get; set; }
        public Electric Electric { get; set; }

        [Key]
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}
