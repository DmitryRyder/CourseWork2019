using System;
using System.ComponentModel;

namespace Common.DTO
{
    public class ManagementBodyDto : BaseDto
    {
        [DisplayName("Название органа управления")]
        public string Name { get; set; }
    }
}
