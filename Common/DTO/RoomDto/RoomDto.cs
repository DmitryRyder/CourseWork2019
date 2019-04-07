﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
    }
}
