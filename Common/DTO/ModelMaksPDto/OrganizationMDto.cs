using System;
using System.ComponentModel;

namespace Common.DTO
{
    public class OrganizationMDto : BaseDto
    {
        [DisplayName("Название организации")]
        public string Name { get; set; }

        public Guid ManagementBodyID { get; set; }
        [DisplayName("Название органа управления")]
        public string ManagementBodyName { get; set; }
    }
}
