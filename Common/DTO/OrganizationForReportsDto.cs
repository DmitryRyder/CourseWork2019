using System;
using System.ComponentModel;

namespace Common.DTO
{
    public class OrganizationForReportsDto : BaseDto
    {
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Почтовый адрес")]
        public string Post { get; set; }
        [DisplayName("Дата выезда")]
        public DateTime InputDate { get; set; }
        [DisplayName("Дата выезда")]
        public DateTime OutputDate { get; set; }
        [DisplayName("Здание")]
        public string BuildingName { get; set; }
        [DisplayName("Номер помещения")]
        public int RoomNumber { get; set; }
    }
}
