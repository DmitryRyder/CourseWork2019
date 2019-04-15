using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Common.DTO
{
    public class TypeOfRoomDto : BaseDto
    {
        [DisplayName("Название")]
        public string Name { get; set; }
    }
}
