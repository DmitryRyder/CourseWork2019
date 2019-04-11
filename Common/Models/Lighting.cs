
namespace Common.Models
{
    public class Lighting : BaseModel
    {
        public int ElectricId { get; set; }
        public Electric Electric { get; set; }
    }
}
