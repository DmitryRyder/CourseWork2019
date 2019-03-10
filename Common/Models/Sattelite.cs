namespace Common.Models
{
    public class Sattelite : BaseModel
    {
        public string OrdinalName { get; set; }
        public string Name { get; set; }
        public int AverageDiameter { get; set; }
        public string Mass { get; set; }
        public int OpeningYear { get; set; }

        public int PlanetId { get; set; }
    }
}
