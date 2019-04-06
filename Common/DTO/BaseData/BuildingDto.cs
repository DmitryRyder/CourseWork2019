using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Common.DTO.BaseData
{
    public class BuildingDto : BaseDto
    {
        [DisplayName("Город")]
        [Required(ErrorMessage = "Требуется название здания")]
        public string Name { get; set; }

        [DisplayName("Почтовый адрес")]
        public string Post { get; set; }

        [DisplayName("Количество этажей")]
        public int Number_of_floors { get; set; }
    }
}
