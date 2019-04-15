using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Common.DTO
{
    public class OrganizationDto : BaseDto
    {
        [DisplayName("Название")]
        [Required(ErrorMessage = "Требуется название организации")]
        public string Name { get; set; }

        [DisplayName("Почтовый адрес")]
        [Required(ErrorMessage = "Требуется название почтовый адрес")]
        public string Post { get; set; }
    }
}
