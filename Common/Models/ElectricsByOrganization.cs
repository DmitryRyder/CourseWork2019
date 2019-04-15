using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    public class ElectricsByOrganization : BaseModel
    {
        //[ForeignKey("ElectricId ")]
        public Guid ElectricId { get; set; }
        public Electric Electric { get; set; }

        //[ForeignKey("OrganizationId")]
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}
