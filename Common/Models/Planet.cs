using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class Planet : BaseModel
    {
        public string Name { get; set; }
        public double SurfaceArea { get; set; }
        public string Mass { get; set; }
        public int Temperature { get; set; }
        public int Radius { get; set; }

        public IList<Sattelite> satellites { get; set; }

        public Planet()
        {
            satellites = new List<Sattelite>();
        }
    }
}
