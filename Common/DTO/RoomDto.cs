using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.DTO
{
    public class RoomDto : BaseDto
    {
        [DisplayName("Номер помещения")]
        [Required(ErrorMessage = "Требуется номер здания")]
        public int Number { get; set; }

        [DisplayName("Площадь")]
        public double Area { get; set; }

        [DisplayName("Этаж")]
        public int Floor { get; set; }
        public Guid Type_of_roomId { get; set; }
        [DisplayName("Тип помещения")]
        public string TypeOfRoomName { get; set; }
        public Guid BuildingId { get; set; }
        [DisplayName("Здание")]
        public string BuildingName { get; set; }
    }
}
