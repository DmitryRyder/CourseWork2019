using Common.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Common.DTO
{
    public class RoomRentalDto : BaseDto
    {
        [DisplayName("Дата въезда")]
        [Required(ErrorMessage = "Введите дату въезда")]
        public DateTime InputDate { get; set; }
        [DisplayName("Дата выезда")]
        [Required(ErrorMessage = "Введите дату выезда")]
        public DateTime OutputDate { get; set; }
        public Guid RoomId { get; set; }
        public RoomDto Room { get; set; }
        public Guid OrganizationId { get; set; }
        public OrganizationDto Organization { get; set; }
    }
}
