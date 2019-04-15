using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Common.DTO
{
    public class ElectricDto : BaseDto
    {
        [DisplayName("Наиманование оборудования")]
        [Required(ErrorMessage = "Требуется наиманование оборудования")]
        public string Name { get; set; }
        [DisplayName("Мощность (в Ваттах) оборудования")]
        [Required(ErrorMessage = "Требуется ввести мощность")]
        public double Power { get; set; }
        [DisplayName("Коэффициент использования (в часах/день)")]
        [Required(ErrorMessage = "Требуется ввести клэффициент")]
        public double UsingOfDay { get; set; }
    }
}
