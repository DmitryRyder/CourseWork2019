using System;
using System.ComponentModel;

namespace Common.DTO
{
    public class SteelPipeDto : BaseDto
    {
        [DisplayName("Тип трубы")]
        public string Name { get; set; }
        [DisplayName("Наружный диаметр")]
        public int Diameter { get; set; }
        [DisplayName("Толщина")]
        public int Thickness { get; set; }
        [DisplayName("Погонный внутренний объем")]
        public int Volume { get; set; }
        [DisplayName("Погонный вес")]
        public int Weight { get; set; }
    }
}
